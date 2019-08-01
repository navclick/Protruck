using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
   public  class VendorVM
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<int> City { get; set; }
        public string CityName { get; set; }
        public Nullable<int> EcomID { get; set; }

    }
}
