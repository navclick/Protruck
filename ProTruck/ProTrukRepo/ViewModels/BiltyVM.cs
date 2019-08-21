using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
    public  class BiltyVM
    {
        public int BiltyNo { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public string VehicleReg { get; set; }

        public Nullable<int> SenderParty { get; set; }
        public string SenderPartyName { get; set; }

        public Nullable<decimal> PaymentCode { get; set; }
        public Nullable<int> DriverId { get; set; }
        public string DriverName { get; set; }

        public string DOs { get; set; }

        public Nullable<decimal> Weight { get; set; }
        public Nullable<int> UnitId { get; set; }
        public string Unit { get; set; }

        public Nullable<double> Rate { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> RemainingAmount { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> BiltyDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> PartyId { get; set; }
        public string PartyName { get; set; }

        public Nullable<decimal> Contractno { get; set; }
        public Nullable<int> GoodTypeId { get; set; }

        public string GoodTypeName { get; set; }
        
    }
}
