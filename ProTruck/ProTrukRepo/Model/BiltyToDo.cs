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
    
    public partial class BiltyToDo
    {
        public int Id { get; set; }
        public Nullable<decimal> Biltyno { get; set; }
        public Nullable<decimal> Donumber { get; set; }
    
        public virtual Dorder Dorder { get; set; }
        public virtual Bilty Bilty { get; set; }
    }
}
