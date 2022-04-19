using Sales_Management_system_.Data;
using Sales_Management_system_.Logic;
using Sales_Management_system_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sales_Management_system_.Areas.Admin.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private readonly StockLogic stockLogic = new StockLogic();
      
        // GET: Admin/Stock  
        [HttpGet]
        public ActionResult AddStock()
        {
           
            StockModel stockModel = new StockModel();
            return View(stockModel);
        }
       
        [HttpPost]
        public ActionResult AddStock(StockModel stock)
        {
            stock.Total_Price = stock.Unit_Price * stock.quantity;
            if (ModelState.IsValid)
            {
             if(stock.quantity!=0&&stock.Unit_Price!=0)
                {
                    int id = stockLogic.addstock(stock);
                    if (id > 0)
                    {
                        return RedirectToAction("ViewStock");
                    }
                }
             else
                {
                    ModelState.AddModelError("", "Product Quantity and Unit Price Must Not be zero");
                }
                
            }
            return View(stock);
        }
        [HttpPost]
        public ActionResult deleteStock(int id)
        {
            if (id != 0)
            {
                 stockLogic.delete(id);
                return RedirectToAction("ViewStock");
            }
            else
            {
                ModelState.AddModelError("", "Id shoud not be null");
            }
            return View("ViewStock");
        }
        public ActionResult ViewStock(string search)
        {
            List<StockModel> product;
            List<StockModel> Stock;
            using(StockDbcontext dbcontext=new StockDbcontext() )
            {
                Stock = stockLogic.getallstock();
                product = stockLogic.searchStock(search);
            }
            if (search != null)
            {
                return View(product);
            }
            return View(Stock);
        }
        public ActionResult UpdateStock()
        {
            List<StockModel> stock=stockLogic.getallstock();
            
            return View(stock);
        }
        
        [HttpGet]
        public ActionResult edit(int id)
        {
            
            var Stock=stockLogic.getStock(id);
            return View(Stock);
        }
        
        [HttpPost]
        public ActionResult edit(StockModel stockModel)
        {
            if (ModelState.IsValid)
            {
                
                stockModel.Total_Price = stockModel.Unit_Price * stockModel.quantity;
                stockLogic.UpdateStock(stockModel.id, stockModel);
                return RedirectToAction("ViewStock");
            }
            return View();
        }
        public ActionResult GenerateInvoice()
        {
            return View();
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "account",new {area=""});
        }
    }
}