using AutoMapper;
using ProTrukRepo.Interface;
using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProTrukRepo.Util;

namespace ProTrukRepo.Repository
{
  public  class BankRepository : IBankRepository
    {

        private readonly ProTruckEntities _db;
        public BankRepository()
        {
            _db = new ProTruckEntities();

            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Bank, BankVM>();
                cfg.CreateMap<BankVM, Bank>();
                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });


        }

        public async Task<Response> GetallBanks()
        {
            try
            {
                List<BankVM> response = new List<BankVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var banksDTO = await _db.Banks.ToListAsync();
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                response = Mapper.Map<IEnumerable<Bank>, List<BankVM>>(banksDTO);
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<BankVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<BankVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<BankVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddBank(BankVM bank)
        {

            var Dto = Mapper.Map<BankVM, Bank>(bank);

            Bank Exist = await _db.Banks.Where(x => x.Bank1.Trim() == bank.Bank1.Trim()).FirstOrDefaultAsync();
            if (Exist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, 0);
            }

            _db.Banks.Add(Dto);

            int result = await _db.SaveChangesAsync();

            if (result == 1)
            {
                // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                return GenericResponses<int>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, result);
            }
            else
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoLoginFailed, (int)Constant.httpStatus.NoContent, result);
            }


        }

        public async Task<Response> RemoveBank(BankVM bank)
        {
            try
            {
                var DTO = await _db.Banks.Where(x => x.Id == bank.Id).FirstOrDefaultAsync();

                _db.Banks.Remove(DTO);

                int result = await _db.SaveChangesAsync();

                if (result == 1)
                {
                    // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                    return GenericResponses<int>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, result);
                }
                else
                {
                    return GenericResponses<int>.ResponseStatus(true, Constant.MSGFailed, (int)Constant.httpStatus.NoContent, result);
                }
            }
            catch (Exception e)
            {
                return GenericResponses<int>.ResponseStatus(true, e.Message, (int)Constant.httpStatus.NoContent, 0);

            }
        }




    }
}
