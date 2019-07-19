using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
   public class GoodsTypeVM
    {
        public int Id { get; set; }
        public string Goods { get; set; }
        public string Description { get; set; }
        public Nullable<int> Unit { get; set; }
        public string UnitName { get; set; }
        public Nullable<int> EcomID { get; set; }



    }
}
