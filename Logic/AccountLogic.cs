using Sales_Management_system_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales_Management_system_.Data
{
    public class AccountLogic
    {
        private readonly StockDbcontext dbcontext = new StockDbcontext();
       public int addaccount(UserModel usermodel)
        {
            var user = new User()
            {
                firstname = usermodel.firstname,
                lastname = usermodel.lastname,
                Username = usermodel.Username,
                password = usermodel.password,
                email = usermodel.email,
                phone = usermodel.phone,
                User_Rights=usermodel.User_Rights
            };
            dbcontext.user.Add(user);
            dbcontext.SaveChanges();
            return user.Uid;
        }
        public bool isvalid(UserModel model)
        {
            bool isvalid = dbcontext.user.Any(x => x.Username == model.Username && x.password == model.password);
            return isvalid;

        }
    }
}