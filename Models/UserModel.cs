using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sales_Management_system_.Models
{
    public class UserModel
    {
        [Key]
        public int Uid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        [Required]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirmpassword { get; set; }
        public string User_Rights { get; set; }
    }
}