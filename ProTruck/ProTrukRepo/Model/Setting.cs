//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProTrukRepo.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Setting
    {
        public int Id { get; set; }
        public Nullable<bool> DoAutoincrement { get; set; }
        public Nullable<decimal> LastDoNumber { get; set; }
        public Nullable<int> PackPerWeight { get; set; }
        public Nullable<int> EcomID { get; set; }
        public Nullable<decimal> LastConractNumber { get; set; }
    
        public virtual ExanaduCompany ExanaduCompany { get; set; }
    }
}
