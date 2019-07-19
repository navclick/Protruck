using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
 public  interface IDriversRepository
    {
        Task<Response> GetallDrivers();

        Task<Response> AddDriver(DriverVM driver);
        Task<Response> RemoveDriver(DriverVM driver);
        
    }
}
