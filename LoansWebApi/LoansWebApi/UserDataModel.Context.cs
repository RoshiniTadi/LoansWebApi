﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoansWebApi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LoanDataSchemaEntities : DbContext
    {
        public LoanDataSchemaEntities()
            : base("name=LoanDataSchemaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAlert> tblAlerts { get; set; }
        public virtual DbSet<tblLoan> tblLoans { get; set; }
        public virtual DbSet<tblLoanStatu> tblLoanStatus { get; set; }
        public virtual DbSet<tblRole> tblRoles { get; set; }
        public virtual DbSet<tblSetting> tblSettings { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblUserAlert> tblUserAlerts { get; set; }
        public virtual DbSet<tblUserLoan> tblUserLoans { get; set; }
    }
}
