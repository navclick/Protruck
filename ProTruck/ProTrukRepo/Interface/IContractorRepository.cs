using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
  public interface IContractorRepository
    {

            Task<Response> GetallContactors();

            Task<Response> AddContractor(ContractorVM contractor);
            Task<Response> RemoveContractor(ContractorVM contractor);

        Response GetallSelectListContractors();

    }
}
