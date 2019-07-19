using ProTrukRepo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
   public interface ISharedRepository
    {
        Response GetallUnits();

        Response GetallVehicleStatus();
        Response GetallVehicleTypes();
        

    }
}
