using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
    public class ModuleVM
    {
        public ModuleVM()
        {
            this.Menus = new HashSet<MenuVM>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Icon { get; set; }

        
        public virtual ICollection<MenuVM> Menus { get; set; }
    }
}
