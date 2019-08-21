using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
public  interface IBiltyRepository
    {

        Task<Response> GetAllBilties();
        //  Response GetUserById(int id);
        Task<Response> GetBilty(decimal biltynumber);

        Task<Response> AddBilty(BiltyVM bilty, decimal[] dos);
       

        Task<Response> GetBiltyByDo(decimal donumber);

        Task<Response> RemoveBilty(BiltyVM bilty);
    }
}
