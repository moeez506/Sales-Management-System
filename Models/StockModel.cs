using Sales_Management_system_.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sales_Management_system_.Models
{
        public class StockModel
        {
        
            public int id { get; set; }
            [Required]
            public string Product_name { get; set; }
            [Required]
            public int  quantity { get; set; }
            [Required]
            public int Unit_Price { get; set; }
            public int Total_Price { get; set; }
    }
}
