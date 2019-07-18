using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
    public class DriverVM
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string DeviceID { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> Vehicle { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> EcomID { get; set; }
        public string VehicleReg { get; set; }

    }
}
