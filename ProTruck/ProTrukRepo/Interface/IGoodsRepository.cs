using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Interface
{
   public interface IGoodsRepository
    {
        Task<Response> GetALLGoods();
        
        Task<Response> AddGood(GoodsTypeVM goods);
        Task<Response> RemoveGood(GoodsTypeVM goods);

        Response GetallUnits();
        


    }
}
