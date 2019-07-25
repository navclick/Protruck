using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
   public interface IContractRespository
    {

        Task<Response> GetallContacts();

        Task<Response> AddContract(ContractVM contract);
        Task<Response> RemoveContract(ContractVM contract);

        Task<Response> GetContract(int Id);

        Task<Response> UpdateContract(ContractTypeVM contract);


    }
}
