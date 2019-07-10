using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
   public class RolesVM
    {
        public int Id { get; set; }
        public string Role1 { get; set; }
        public string Desc { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> EcomID { get; set; }

        public virtual ICollection<UserVM> Users { get; set; }
    }
}
