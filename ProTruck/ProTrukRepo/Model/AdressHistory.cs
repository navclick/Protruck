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
    
    public partial class AdressHistory
    {
        public int Id { get; set; }
        public Nullable<int> Party { get; set; }
        public string EnglisgAddress { get; set; }
        public string UrduAddress { get; set; }
    
        public virtual Party Party1 { get; set; }
    }
}
