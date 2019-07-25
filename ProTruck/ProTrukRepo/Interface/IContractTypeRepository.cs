using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
 public   interface IContractTypeRepository
    {

        Task<Response> GetallContractTrypes();

        Task<Response> AddContractType(ContractTypeVM contracttype);
        Task<Response> RemoveContractType(ContractTypeVM contracttype);
    }
}
