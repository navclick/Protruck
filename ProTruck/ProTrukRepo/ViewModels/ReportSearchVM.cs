using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
   public  class ReportSearchVM
    {

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }

        public string FiledoneLabel { get; set; }
        public string FiledoneName { get; set; }
        public bool FiledoneEnable { get; set; }

        public string FiledtwoLabel { get; set; }
        public string FiledtwoName { get; set; }
        public bool FiledtwoEnable { get; set; }


        public string DropdownoneLable { get; set; }
        public string DropdownoneName { get; set; }
        public bool DropdownoneEnable { get; set; }

        public List<DropDownListModel> DropdownoneList { get; set; }
        public string DropdownoneValue { get; set; }




    }
}
