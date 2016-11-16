using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace test_lightpoint.Models
{
    public class ShopContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }  

        public ShopContext():base("DefaultConnection")
        { }
    }
}