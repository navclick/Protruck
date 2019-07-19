using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
 public  class ExpenseVM
    {
        public int Id { get; set; }
        public string Expense1 { get; set; }
        public string Description { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> EcomID { get; set; }

        public string TypeName { get; set; }


    }
}
