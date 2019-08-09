using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
  public   class ContractVM
    {

        public int Id { get; set; }
        public Nullable<decimal> ContractNo { get; set; }
        public Nullable<int> ContractType { get; set; }
        public string ContractTypeName { get; set; }
        public Nullable<int> Party { get; set; }
        public string PartyName { get; set; }
        public Nullable<double> TotatQty { get; set; }
        public Nullable<int> Unit { get; set; }
        public string UnitName { get; set; }
        public Nullable<int> EcomID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }

    }
}
