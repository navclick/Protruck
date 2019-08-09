using AutoMapper;
using ProTrukRepo.Interface;
using ProTrukRepo.Model;
using ProTrukRepo.Util;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProTrukRepo.Repository
{
  public  class DoRepository : IDoRepository
    {

        private readonly ProTruckEntities _db;
        public DoRepository()
        {
            _db = new ProTruckEntities();

            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Dorder, DorderVM>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.City1.Trim()))
                .ForMember(dest => dest.ContractTypeName, opt => opt.MapFrom(src => src.ContractType1.Type.Trim()))
                .ForMember(dest => dest.GoodsTypeName, opt => opt.MapFrom(src => src.GoodsType1.Goods.Trim()))
                .ForMember(dest => dest.PartyName, opt => opt.MapFrom(src => src.Party1.Party1.Trim()));
              


                cfg.CreateMap<DorderVM, Dorder>();
                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });


        }

        public async Task<Response> GetAllDos()
        {
            try
            {
                List<DorderVM> response = new List<DorderVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var DTO = await _db.Dorders.ToListAsync();
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                response = Mapper.Map<IEnumerable<Dorder>, List<DorderVM>>(DTO);
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<DorderVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<DorderVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<DorderVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddDo(DorderVM dorder)
        {

            var Dto = Mapper.Map<DorderVM, Dorder>(dorder);

            Dorder Exist = await _db.Dorders.Where(x => x.DoNumber == dorder.DoNumber).FirstOrDefaultAsync();
            if (Exist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, -1);
            }

            _db.Dorders.Add(Dto);

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

        public async Task<Response> RemoveDo(DorderVM dorder)
        {
            try
            {
                var DTO = await _db.Dorders.Where(x => x.Id == dorder.Id).FirstOrDefaultAsync();

                _db.Dorders.Remove(DTO);

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



        public async Task<Response> GetDo(decimal Id)
        {
            try
            {
                var DTO = await _db.Dorders.Where(x => x.Id == Id).FirstOrDefaultAsync();

                if (DTO != null)
                {
                    var Obj = Mapper.Map<Dorder, DorderVM>(DTO);

                    return GenericResponses<DorderVM>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, Obj);
                }
                else
                {
                    return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, 0);

                }


            }
            catch (Exception e)
            {
                return GenericResponses<int>.ResponseStatus(true, e.Message, (int)Constant.httpStatus.NoContent, 0);

            }
        }


        public async Task<Response> updateDo(DorderVM dorder)
        {
            try
            {
                Dorder DTO = Mapper.Map<DorderVM, Dorder>(dorder);



                _db.Dorders.Add(DTO);

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



    }
}
