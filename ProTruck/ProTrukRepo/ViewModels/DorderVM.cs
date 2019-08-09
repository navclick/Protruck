using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
    public class DorderVM
    {

        public int Id { get; set; }
        public Nullable<decimal> DoNumber { get; set; }
        public Nullable<decimal> ContractNumber { get; set; }
        public string ContractTypeName { get; set; }
        public Nullable<int> ContractType { get; set; }
        public Nullable<int> QTY { get; set; }
        public Nullable<int> GoodsType { get; set; }
        public string GoodsTypeName { get; set; }
        public string AddressEng { get; set; }
        public string AddressUrd { get; set; }
        public Nullable<int> CityID { get; set; }
        public string CityName { get; set; }
        public Nullable<int> Party { get; set; }

        public bool autoincrement { get; set; }

        public string PartyName { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<int> Unit { get; set; }
        public Nullable<decimal> Attached { get; set; }
        public Nullable<System.DateTime> DoDate { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> EcomID { get; set; }
        public int SaveCopy { get; set; }

        public int BagsPerWeight { get; set; }
    }
}
