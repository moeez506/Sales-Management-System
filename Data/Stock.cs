using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sales_Management_system_.Data
{
    [Table("Stock")]
    public class Stock
    {
        public int id { get; set; }
        public string Product_name { get; set; }
        public int quantity { get; set; }
        public int Unit_Price { get; set; }
        public int Total_Price { get; set; }
    }
}