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
   public class VehicleRepository : IVehicleRepository
    {
        private readonly ProTruckEntities _db;
        
        private SharedRepository _shareRepo;
        public VehicleRepository()
        {
            _db = new ProTruckEntities();
           

            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<vehicle, VehicleVM>();
                cfg.CreateMap<VehicleVM, vehicle>();
                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });

            _shareRepo = new SharedRepository();
        }

        public async Task<Response> GetallVehicles()
        {
            try
            {
                List<VehicleVM> response = new List<VehicleVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var vehiclesDTO = await _db.vehicles.ToListAsync();
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                // response = Mapper.Map<IEnumerable<GoodsType>, List<GoodsTypeVM>>(goods);

                foreach (var vehicle in vehiclesDTO) {
                    VehicleVM obj = new VehicleVM();
                    obj.Capacity = vehicle.Capacity;
                    obj.CreatedOn = vehicle.CreatedOn;
                    obj.EcomID = vehicle.EcomID;
                    obj.Id = vehicle.Id;
                    obj.Manufacturer = vehicle.Manufacturer;
                    obj.Model = vehicle.Model;
                    obj.RegNumber = vehicle.RegNumber;
                    obj.Status = vehicle.Status;
                    obj.StatusName = _shareRepo.GetVehicleStatusByID((int)vehicle.Status);
                    obj.Type = vehicle.Type;
                    obj.TypeName= _shareRepo.GetVehicleTypeID((int)vehicle.Type);
                    obj.Unit = vehicle.Unit;
                    obj.UnitName = _shareRepo.GetUnitByID((int)vehicle.Unit);
                    response.Add(obj);
                }

                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<VehicleVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<VehicleVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<VehicleVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddVehicle(VehicleVM vehicle)
        {

            var vehicleDto = Mapper.Map<VehicleVM, vehicle>(vehicle);

            vehicle vehicleExist = await _db.vehicles.Where(x => x.RegNumber.Trim() == vehicle.RegNumber.Trim()).FirstOrDefaultAsync();
            if (vehicleExist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, 0);
            }

            _db.vehicles.Add(vehicleDto);

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

        public async Task<Response> RemoveVehicle(VehicleVM vehicle)
        {
            try
            {
                var vehicleDTO = await _db.vehicles.Where(x => x.Id == vehicle.Id).FirstOrDefaultAsync();

                _db.vehicles.Remove(vehicleDTO);

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

        public Response GetallUnits()
        {

            return _shareRepo.GetallUnits();
        }

        public Response GetallVehicleType()
        {

            return _shareRepo.GetallVehicleTypes();
        }

        public Response GetallVehicleStatus()
        {

            return _shareRepo.GetallVehicleStatus();
        }

        public Response GetallSelectListVehicles()
        {
            var vehiclesDTO =  _db.vehicles.ToList();
            List<DropDownListModel> Lst = new List<DropDownListModel>();
            foreach (var vehicle  in vehiclesDTO)
            {
                DropDownListModel obj = new DropDownListModel();
                obj.Value = (int)vehicle.Id;
                obj.Text = vehicle.RegNumber.ToString();
                Lst.Add(obj);
                // Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }

            return GenericResponses<List<DropDownListModel>>.ResponseStatus(false, Lst.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, Lst);
        }

    }
}
