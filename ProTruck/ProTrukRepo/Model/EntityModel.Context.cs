﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProTruckEntities : DbContext
    {
        public ProTruckEntities()
            : base("name=ProTruckEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<ExanaduCompany> ExanaduCompanies { get; set; }
        public virtual DbSet<GoodsType> GoodsTypes { get; set; }
        public virtual DbSet<LinkRoleMenu> LinkRoleMenus { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Party> Parties { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ContractType> ContractTypes { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Dorder> Dorders { get; set; }
        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<vehicle> vehicles { get; set; }
    }
}
