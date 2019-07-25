using AutoMapper;
using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProTrukRepo.Util;
using ProTrukRepo.Interface;

namespace ProTrukRepo.Repository
{
   public  class ContractTypeRepository : IContractTypeRepository
    {

        private readonly ProTruckEntities _db;
        public ContractTypeRepository()
        {
            _db = new ProTruckEntities();

            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ContractType, ContractTypeVM>();
                cfg.CreateMap<ContractTypeVM, ContractType>();
                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });


        }

        public async Task<Response> GetallContractTrypes()
        {
            try
            {
                List<ContractTypeVM> response = new List<ContractTypeVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var DTO = await _db.ContractTypes.ToListAsync();
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                response = Mapper.Map<IEnumerable<ContractType>, List<ContractTypeVM>>(DTO);
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<ContractTypeVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<ContractTypeVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<ContractTypeVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddContractType(ContractTypeVM contracttype)
        {

            var Dto = Mapper.Map<ContractTypeVM, ContractType>(contracttype);

            ContractType Exist = await _db.ContractTypes.Where(x => x.Type.Trim() == contracttype.Type.Trim()).FirstOrDefaultAsync();
            if (Exist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, 0);
            }

            _db.ContractTypes.Add(Dto);

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

        public async Task<Response> RemoveContractType(ContractTypeVM contracttype)
        {
            try
            {
                var DTO = await _db.ContractTypes.Where(x => x.Id == contracttype.Id).FirstOrDefaultAsync();

                _db.ContractTypes.Remove(DTO);

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
