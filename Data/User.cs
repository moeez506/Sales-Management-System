using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sales_Management_system_.Data
{
    [Table("Userinfo")]
    public class User
    {
        [Key]
        public int Uid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public string User_Rights { get; set; }
    }
}