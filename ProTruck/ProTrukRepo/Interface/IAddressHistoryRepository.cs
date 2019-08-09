using ProTrukRepo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
 public interface IAddressHistoryRepository
    {
        bool isInsertable(int party);
        bool AddAddressHistory(AdressHistory address);

        bool updqateAddressHistory(AdressHistory address);

        Task<Response> GetAddressHistory(int party);
    }
}
