using ProTrukRepo.Model;
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
        
        Task<Response> AddGood(GoodsType goods);
        Task<Response> RemoveGood(GoodsType goods);

        Response GetallUnits();
        


    }
}
