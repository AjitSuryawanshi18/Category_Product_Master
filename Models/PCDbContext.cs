using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Category_Product.Models
{
    public class PCDbContext : DbContext
    {
        public PCDbContext() : base("name=DbCon_Connection")
        {

        }
        public DbSet<Category> CategoriesTable { get; set; }
        public DbSet<Product> ProductsTable { get; set; }
    }
}
