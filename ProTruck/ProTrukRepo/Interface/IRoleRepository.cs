using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
   public interface IRoleRepository
    {

        Task<Response> GetAllRoles();
        //  Response GetUserById(int id);
    //    Response ValidateUser(UserVM user);
      //  Response GetModules();
        //Response AddUser(UserVM employee);
        Task<Response> AddRole(RolesVM role);
        Task<Response> RemoveRole(RolesVM role);
        //Task<bool> RemoveUser(UserVM user);


        //Task<Response> GetAllRoles();

    }
}
