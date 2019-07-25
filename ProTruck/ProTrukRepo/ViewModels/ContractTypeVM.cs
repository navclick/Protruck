using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
   public class ContractTypeVM
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Nullable<int> EcomID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }

    }
}
