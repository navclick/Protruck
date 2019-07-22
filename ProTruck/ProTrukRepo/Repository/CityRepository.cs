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
   public class CityRepository: ICityRepository
    {
        private readonly ProTruckEntities _db;

        public CityRepository()
        {
            _db = new ProTruckEntities();

            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<City, CityVM>();
                cfg.CreateMap<CityVM, City>();
                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });





        }

        public async Task<Response> GetALLCities()
        {
            try
            {
                List<CityVM> response = new List<CityVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var DTO = await _db.Cities.ToListAsync();
               

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                response = Mapper.Map<IEnumerable<City>, List<CityVM>>(DTO);
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<CityVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<CityVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<CityVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddCity(CityVM city)
        {

            var Dto = Mapper.Map<CityVM, City>(city);

            City Exist = await _db.Cities.Where(x => x.City1.Trim() == city.City1.Trim()).FirstOrDefaultAsync();
            if (Exist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, 0);
            }

            _db.Cities.Add(Dto);

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

        public async Task<Response> RemoveCity(CityVM city)
        {
            try
            {
                var DTO = await _db.Cities.Where(x => x.Id == city.Id).FirstOrDefaultAsync();

                _db.Cities.Remove(DTO);

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

        public Response GetCitiesSelectList()
        {
            var DTO = _db.Cities.ToList();
            List<DropDownListModel> Lst = new List<DropDownListModel>();
            foreach (var city in DTO)
            {
                DropDownListModel obj = new DropDownListModel();
                obj.Value = (int)city.Id;
                obj.Text =  city.City1;
                Lst.Add(obj);
                // Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }

            return GenericResponses<List<DropDownListModel>>.ResponseStatus(false, Lst.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, Lst);
        }



        


    }
}
