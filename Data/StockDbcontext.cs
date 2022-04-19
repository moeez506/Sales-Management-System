using Sales_Management_system_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sales_Management_system_.Data
{
    public class StockDbcontext:DbContext
    {
        public DbSet<Stock> stocks { get; set; }
        public DbSet<User> user { get; set; }

    }
}