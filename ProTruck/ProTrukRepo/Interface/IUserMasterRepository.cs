using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
   public interface IUserMasterRepository
    {
        Response GetAllUsers();
      //  Response GetUserById(int id);
        Response ValidateUser(UserVM user);
        Response GetModules();
        //Response AddUser(UserVM employee);

    }
}
