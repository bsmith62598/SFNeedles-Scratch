﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NeedlesAndScratch.DATA.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NeedlesAndScratchEntities : DbContext
    {
        public NeedlesAndScratchEntities()
            : base("name=NeedlesAndScratchEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Band> Bands { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<StockStatu> StockStatus { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
    }
}
