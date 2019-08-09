using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
    public class PartyVM
    {
        public int Id { get; set; }
        public string Party1 { get; set; }
        public string ConectPerson { get; set; }
        public string Phone { get; set; }

        public string SenderOrReceiver { get; set; }
        public Nullable<bool> IsSubParty { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> EcomID { get; set; }

        public string ParentPartyName { get; set; }
    }
}
