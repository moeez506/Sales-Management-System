using Sales_Management_system_.Data;
using Sales_Management_system_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales_Management_system_.Logic
{
    public class StockLogic
    {
        private readonly StockDbcontext dbcontext = new StockDbcontext();
       
        public int addstock(StockModel stockModel)
        {
            var stock = new Stock()
            {
                Product_name = stockModel.Product_name,
                quantity = stockModel.quantity,
                Unit_Price = stockModel.Unit_Price,
                Total_Price = stockModel.Total_Price
            };
            dbcontext.stocks.Add(stock);
            dbcontext.SaveChanges();
            return stock.id;

        }
        public void delete(int id)
        {
            Stock stockModel = dbcontext.stocks.Find(id);
            dbcontext.stocks.Remove(stockModel);
            dbcontext.SaveChanges();
        }
        public List<StockModel> searchStock(string search)
        {
            var Stock = dbcontext.stocks.ToArray().Where(x=>x.Product_name==search).Select(x => new StockModel()
            {
                id = x.id,
                Product_name = x.Product_name,
                Unit_Price = x.Unit_Price,
                Total_Price = x.Total_Price,
                quantity = x.quantity
            }).ToList();
            return Stock;
        }
        public List<StockModel> getallstock()
        {
            var Stock = dbcontext.stocks.ToArray().Select(x => new StockModel()
            {
                id = x.id,
                Product_name = x.Product_name,
                Unit_Price = x.Unit_Price,
                Total_Price = x.Total_Price,
                quantity = x.quantity
            }).ToList();
            return Stock;
        }
        public StockModel getStock(int id)
        {
           
            StockModel Stock = dbcontext.stocks.ToArray().Where(x=>x.id==id).Select(x=>new StockModel() { 
             id=x.id,
             Product_name=x.Product_name,
             Unit_Price=x.Unit_Price,
             Total_Price=x.Total_Price,
             quantity=x.quantity
            }).FirstOrDefault();
            return Stock;
        }
        public bool UpdateStock(int id,StockModel model)
        {
            var stock = dbcontext.stocks.FirstOrDefault(x => x.id == id);
            if (stock != null)
            {
                stock.Product_name = model.Product_name;
                stock.quantity = model.quantity;
                stock.Unit_Price = model.Unit_Price;
                stock.Total_Price = model.Total_Price;
            }
            dbcontext.SaveChanges();
            return true;
        }
    }
}