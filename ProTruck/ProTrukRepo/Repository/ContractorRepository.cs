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
   public  class ContractorRepository : IContractorRepository
    {


        private readonly ProTruckEntities _db;
        public ContractorRepository()
        {
            _db = new ProTruckEntities();

            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Contractor, ContractorVM>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City1.City1.Trim())); ;
                cfg.CreateMap<ContractorVM, Contractor>();
                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });


        }

        public async Task<Response> GetallContactors()
        {
            try
            {
                List<ContractorVM> response = new List<ContractorVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var DTO = await _db.Contractors.ToListAsync();
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                response = Mapper.Map<IEnumerable<Contractor>, List<ContractorVM>>(DTO);
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<ContractorVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<ContractorVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<ContractorVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddContractor(ContractorVM contractor)

        {

            var Dto = Mapper.Map<ContractorVM, Contractor>(contractor);

            Contractor Exist = await _db.Contractors.Where(x => x.Name.Trim() == contractor.Name.Trim()).FirstOrDefaultAsync();
            if (Exist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, 0);
            }

            _db.Contractors.Add(Dto);

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

        public async Task<Response> RemoveContractor(ContractorVM contractor)
        {
            try
            {
                var DTO = await _db.Contractors.Where(x => x.Id == contractor.Id).FirstOrDefaultAsync();

                _db.Contractors.Remove(DTO);

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

        public Response GetallSelectListContractors()
        {
            var DTO = _db.Contractors.ToList();
            List<DropDownListModel> Lst = new List<DropDownListModel>();
            foreach (var DTobj in DTO)
            {
                DropDownListModel obj = new DropDownListModel();
                obj.Value = (int)DTobj.Id;
                obj.Text = DTobj.Name;
                Lst.Add(obj);
                // Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }

            return GenericResponses<List<DropDownListModel>>.ResponseStatus(false, Lst.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, Lst);
        }

    }
}
