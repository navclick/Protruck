using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
   public interface IVendorRepository
    {
        Task<Response> GetallVendors();

        Task<Response> AddVendor(VendorVM vendor);
        Task<Response> RemoveVendor(VendorVM vendor);
    }
}
