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
    public class DriverRepository : IDriversRepository
    {


        private readonly ProTruckEntities _db;
        public DriverRepository()
        {
            _db = new ProTruckEntities();
            
            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Driver, DriverVM>().ForMember(dest => dest.VehicleReg, opt => opt.MapFrom(src => src.vehicle1.RegNumber.Trim())); ; ;
                cfg.CreateMap<DriverVM, Driver>();
                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });

            
        }

        public async Task<Response> GetallDrivers()
        {
            try
            {
                List<DriverVM> response = new List<DriverVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var drivers = await _db.Drivers.ToListAsync();
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                response = Mapper.Map<IEnumerable<Driver>, List<DriverVM>>(drivers);
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<DriverVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<DriverVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<DriverVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddDriver(DriverVM driver)
        {

            var Dto = Mapper.Map<DriverVM, Driver>(driver);

            Driver Exist = await _db.Drivers.Where(x => x.Name.Trim() == driver.Name.Trim()).FirstOrDefaultAsync();
            if (Exist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, 0);
            }

            _db.Drivers.Add(Dto);

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

        public async Task<Response> RemoveDriver(DriverVM driver)
        {
            try
            {
                var DTO = await _db.Drivers.Where(x => x.Id == driver.Id).FirstOrDefaultAsync();

                _db.Drivers.Remove(DTO);

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


        public async Task<Response> GetDriverByVehicle(int vehicleId)
        {
            try
            {
                var DTO = await _db.Drivers.Where(x => x.Vehicle == vehicleId).FirstOrDefaultAsync();
 

               
              

                if (DTO != null)
                {
                    // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                    var Obj = Mapper.Map<Driver, DriverVM>(DTO);
                    return GenericResponses<DriverVM>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, Obj);
                }
                else
                {
                    return GenericResponses<int>.ResponseStatus(true, Constant.MSGFailed, (int)Constant.httpStatus.NoContent, 0);
                }
            }
            catch (Exception e)
            {
                return GenericResponses<int>.ResponseStatus(true, e.Message, (int)Constant.httpStatus.NoContent, 0);

            }
        }


    }
}
