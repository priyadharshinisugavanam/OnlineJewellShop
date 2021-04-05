using OnlineJewellShop.BL;
using OnlineJewellShop.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineJewellShop.Controllers
{
    [Authorize(Roles = "User")]
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
                IEnumerable<ProductCatogeries> products = productCategoryBL.DisplayProduct();
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