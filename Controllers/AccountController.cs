using Sales_Management_system_.Data;
using Sales_Management_system_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sales_Management_system_.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountLogic logic = new AccountLogic();
        // GET: Account
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(UserModel model) 
        {

            if (logic.isvalid(model))
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return RedirectToAction("ViewStock", "Stock",new {area="Admin" });
            }
            else
            {
                ViewBag.message = "Invalid username or password";
                //ModelState.AddModelError("", "invalid username and password");
            }
            return View(model);
        }
        public ActionResult Signup()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Signup(UserModel model)
        {
            if (ModelState.IsValid)
            {
                int id = logic.addaccount(model);
                if (id > 0)
                {
                    return RedirectToAction("login");
                }
            }
            return View();
        }
        
    }
}