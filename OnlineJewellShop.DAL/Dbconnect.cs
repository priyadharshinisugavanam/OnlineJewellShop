using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJewellShop.DAL
{
    public class DbConnect : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().MapToStoredProcedures();
            modelBuilder.Entity<User>().MapToStoredProcedures();
            modelBuilder.Entity<ProductCatogeries>().MapToStoredProcedures();
        }
        public DbSet<Product> ProductData { get; set; }
        public DbSet<ProductCatogeries> ProductCategoryData { get; set; }
        public DbSet<User> Data { get; set; }
        public DbConnect() : base("DBConnection")
        {

        }

    }
}
