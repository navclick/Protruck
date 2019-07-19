using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
   public interface IBankRepository
    {
        Task<Response> GetallBanks();

        Task<Response> AddBank(BankVM bank);
        Task<Response> RemoveBank(BankVM bank);

        
       // Response GetallSelectListBanks();

    }
}
