using Kit19WebApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kit19WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ProductDAL productDAL = new ProductDAL();
            List<Product> products = productDAL.getProducts();
            return View(products);
        }
        

    [HttpPost] 
        public ActionResult Index(string ProductName, string Size, int? Price,
       DateTime? MfgDate, string Category)
        {
            string conjuctionOp = Request.Form["Operator"];
           
            if (conjuctionOp == null || conjuctionOp == string.Empty)
            {
                conjuctionOp = "and";
            }
            List<Product> products = null;

            ProductDAL productDAL = new ProductDAL();
                products = productDAL.searchProducts(conjuctionOp, ProductName, Size, 
                    Price, MfgDate, Category);
            ModelState.Clear();
                return View(products);
            

        }

    }
}