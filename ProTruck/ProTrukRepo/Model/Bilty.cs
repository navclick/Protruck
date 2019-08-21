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
    
    public partial class Bilty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bilty()
        {
            this.BiltyToDos = new HashSet<BiltyToDo>();
        }
    
        public decimal BiltyNo { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public Nullable<int> SenderParty { get; set; }
        public Nullable<decimal> PaymentCode { get; set; }
        public Nullable<int> DriverId { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<int> UnitId { get; set; }
        public Nullable<double> Rate { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> RemainingAmount { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> BiltyDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> PartyId { get; set; }
        public Nullable<decimal> Contractno { get; set; }
        public Nullable<int> GoodTypeId { get; set; }
    
        public virtual Driver Driver { get; set; }
        public virtual GoodsType GoodsType { get; set; }
        public virtual Party Party { get; set; }
        public virtual vehicle vehicle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BiltyToDo> BiltyToDos { get; set; }
    }
}