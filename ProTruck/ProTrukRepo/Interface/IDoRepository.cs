using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
   public interface IDoRepository
    {

        Task<Response> GetAllDos();
        //  Response GetUserById(int id);
       Task<Response> GetDo(decimal donumber);
        Task<Response> updateDo(DorderVM dorder);
        //Response AddUser(UserVM employee);
        Task<Response> AddDo(DorderVM dorder);
        Task<Response> RemoveDo(DorderVM dorder);

    }
}
