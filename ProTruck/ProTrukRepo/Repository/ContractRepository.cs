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
 public  class ContractRepository : IContractRespository
    {

        private readonly ProTruckEntities _db;
        public ContractRepository()
        {
            _db = new ProTruckEntities();

            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Contract, ContractVM>().ForMember(dest => dest.PartyName, opt => opt.MapFrom(src => src.Party1.Party1.Trim()))
                .ForMember(dest => dest.ContractTypeName, opt => opt.MapFrom(src => src.ContractType1.Type.Trim()));


                cfg.CreateMap<ContractVM, Contract>();
                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });


        }

        public async Task<Response> GetallContacts()
        {
            try
            {
                List<ContractVM> response = new List<ContractVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var DTO = await _db.Contracts.ToListAsync();
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                response = Mapper.Map<IEnumerable<Contract>, List<ContractVM>>(DTO);
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<ContractVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<ContractVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<ContractVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddContract(ContractVM contract)
        {

            var Dto = Mapper.Map<ContractVM, Contract>(contract);

            Contract Exist = await _db.Contracts.Where(x => x.ContractNo == contract.ContractNo).FirstOrDefaultAsync();
            if (Exist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, -1);
            }

            _db.Contracts.Add(Dto);

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

        public async Task<Response> RemoveContract(ContractVM contract)
        {
            try
            {
                var DTO = await _db.Contracts.Where(x => x.Id == contract.Id).FirstOrDefaultAsync();

                _db.Contracts.Remove(DTO);

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



        public async Task<Response> GetContract(int Id)
        {
            try
            {
                var DTO = await _db.Contracts.Where(x => x.Id == Id).FirstOrDefaultAsync();

                if (DTO != null)
                {
                    var ContratObj = Mapper.Map<Contract, ContractVM>(DTO);

                    return GenericResponses<ContractVM>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, ContratObj);
                }
                else {
                    return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, 0);

                }


            }
            catch (Exception e)
            {
                return GenericResponses<int>.ResponseStatus(true, e.Message, (int)Constant.httpStatus.NoContent, 0);

            }
        }


        public async Task<Response> UpdateContract(ContractVM contract)
        {
            try
            {
                Contract DTO = Mapper.Map<ContractVM, Contract>(contract);



                _db.Contracts.Add(DTO);

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
            catch (Exception e)
            {
                return GenericResponses<int>.ResponseStatus(true, e.Message, (int)Constant.httpStatus.NoContent, 0);

            }
        }


        public async Task<Response> UpdateContractQty(ContractVM contract)
        {
            try
            {

                Contract DTO = await _db.Contracts.Where(x => x.ContractNo == contract.ContractNo).FirstOrDefaultAsync();

                DTO.TotatQty = (DTO.TotatQty + contract.TotatQty);



               
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
            catch (Exception e)
            {
                return GenericResponses<int>.ResponseStatus(true, e.Message, (int)Constant.httpStatus.NoContent, 0);

            }
        }


        public bool isInsertable(ContractVM contract)
        {
            try
            {
               
                //var users =  _db.Users.Select(x => x).ToList();
                var DTO =  _db.Contracts.Where(x => x.ContractNo == contract.ContractNo).ToList();

                if (DTO.Count < 1)
                {

                    return true;
                }

                else { return false; }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
