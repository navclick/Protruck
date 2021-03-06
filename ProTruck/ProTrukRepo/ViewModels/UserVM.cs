﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.ViewModels
{
  public class UserVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Nullable<int> AccountStatus { get; set; }
        public int RoleID { get; set; }
        public string Picture { get; set; }
        public string CreatedOn { get; set; }
        public int EcomID { get; set; }
        public string Role { get; set; }


    }
}
