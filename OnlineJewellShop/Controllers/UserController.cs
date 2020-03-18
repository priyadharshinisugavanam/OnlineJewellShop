using OnlineJewellShop.BL;
using OnlineJewellShop.DAL;
using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewellShop.Controllers
{
    public class UserController : Controller
    {
        IProductCategoryBL productCategoryBL;
        IProductBL productBL;
        //creating reference for interface
        public UserController()
        {
            productCategoryBL = new ProductCategoryBL();
            productBL = new ProductBL();
        }
        //to get the user operations
        public ActionResult UserOperation()
        {
            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        //view the category
        public ActionResult ViewProductCategory()
        {
            try
            {
                IEnumerable<ProductCatogeries> products = productCategoryBL.GetProductCatogeries();
                return View(products);
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpGet]//get method for getting productcategory
        public ActionResult ProductsDetail(int id)
        {
            try
            {
                List<Product> products = (List<Product>)productBL.GetProductCategory(id);
                return View(products);
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
    }
}