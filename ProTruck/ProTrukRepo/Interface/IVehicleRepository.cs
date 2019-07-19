using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
  public  interface IVehicleRepository
    {
        Task<Response> GetallVehicles();

        Task<Response> AddVehicle(VehicleVM vehicle);
        Task<Response> RemoveVehicle(VehicleVM vehicle);

        Response GetallUnits();
        Response GetallVehicleType();
        Response GetallVehicleStatus();
        Response GetallSelectListVehicles();

    }
}
