using DataObjectAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectAccess
{
    /// <summary>
    /// DAO
    /// </summary>
    public class SaleContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CategoryOfProduct> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Import> Imports { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }

        public SaleContext():base("SaleDB")
        {
            base.Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
