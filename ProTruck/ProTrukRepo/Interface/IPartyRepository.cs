using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
   public interface IPartyRepository
    {

        Task<Response> GetALLParties();

        Task<Response> GetALLSenderParties();

        Task<Response> AddParty(PartyVM party);
        Task<Response> RemoveParty(PartyVM party);
        Response GetallSelectListParties();


    }
}
