using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BGSBcodefirst.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("bankDb") { }
        public DbSet<AccountDetail> AccountDetails { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Beneficiary> Beneficiaries{ get; set; }
        public DbSet<AtmCumDebitCard> AtmCumDebitCards{ get; set; }
        public DbSet<Transaction> Transactions{ get; set; }
        public DbSet<ServicesSubscribed> ServicesSubscribeds{ get; set; }
        public DbSet<ServiceRequestNo> ServiceRequestNos{ get; set; }
    }
}