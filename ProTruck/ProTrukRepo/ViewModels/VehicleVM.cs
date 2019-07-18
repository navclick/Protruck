using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
   public class VehicleVM
    {
        public int Id { get; set; }
        public string RegNumber { get; set; }
        public Nullable<int> Type { get; set; }
        public string TypeName { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public Nullable<int> Capacity { get; set; }
        public Nullable<int> Unit { get; set; }
        public string UnitName { get; set; }
        public Nullable<int> Status { get; set; }
        public string StatusName { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> EcomID { get; set; }
    }
}
