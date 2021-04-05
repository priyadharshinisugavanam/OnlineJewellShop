using OnlineJewellShop.BL;
using OnlineJewellShop.Entity;
using OnlineJewellShop.Models;
using System.Collections.Generic;
using System.IO;
using System;
using System.Web.Mvc;

namespace OnlineJewellShop.Controllers
{
   [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        IProductCategoryBL productCategoryDetails;
        IProductBL productDetails;
        IUserBL userDetailsBL;
        //creating reference to interfaces
        public AdminController()
        {
            productDetails = new ProductBL();
            productCategoryDetails = new ProductCategoryBL();
            userDetailsBL = new UserBL();
        }
        //getting the product from admin
        [HttpGet]
        public ActionResult AddProduct()
        {
            try
            {
                ViewBag.ProductCategories = new SelectList(productCategoryDetails.DisplayProduct(), "ProductCatogeryId", "productCatogeryName");
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpPost]//posting to the view
        public ActionResult AddProduct(ProductModel image)
        {
            try
            {
                ViewBag.ProductCategories = new SelectList(productCategoryDetails.DisplayProduct(), "ProductCatogeryId", "productCatogeryName");
                
               
                 if (ModelState.IsValid)
                {
                    string filename = Path.GetFileNameWithoutExtension(image.ImageUpload.FileName);
                    string extension = Path.GetExtension(image.ImageUpload.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    image.ProductImagePath = filename;
                    OnlineJewellShop.Entity.Product productMap = AutoMapper.Mapper.Map<ProductModel, Product>(image);
                    filename = Path.Combine(Server.MapPath("~/ProductImages/"), filename);
                    if (extension == ".jpg" || extension == ".png")
                    {
                        image.ImageUpload.SaveAs(filename);

                        int result = productDetails.AddProduct(productMap);
                        if (result > 0)
                        {

                            return RedirectToAction("ViewProduct");
                        }
                    }
                    else
                    {
                        ViewBag.Image = "Selected file is not in the correct format please select image file";

                    }
                }
               
                return View();

            }

            catch
            {
                return RedirectToAction("Error", "Error");
            }

        }
        //view the product to admin
        public ActionResult ViewProduct()
        {
            try
            {
                IEnumerable<Product> products = productDetails.DisplayProduct();
                return View(products);
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }//provides the admins operation
        public ActionResult AdminOperation()
        {
            
           
                return View();
           
        }
        [HttpGet]//getting the edit object from admin
        public ActionResult EditProduct(int id)
        {
            try
            {
               
                ViewBag.ProductCategories = new SelectList(productCategoryDetails.DisplayProduct(), "ProductCatogeryId", "productCatogeryName");
                
                Product product = productDetails.GetProduct(id);
                TempData["Image"] = product.ProductImagePath;
                return View(product);
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpPost]//posting to the view
        public ActionResult EditProduct(ProductModel image)
        {
            string filename = null;
            string extension;
            ViewBag.ProductCategories = new SelectList(productCategoryDetails.DisplayProduct(), "ProductCatogeryId", "productCatogeryName");
            if (image.ImageUpload == null)
            {
                image.ProductImagePath = Convert.ToString(TempData["Image"]);
            }
            else 
            {
                filename = Path.GetFileNameWithoutExtension(image.ImageUpload.FileName);
                extension = Path.GetExtension(image.ImageUpload.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                image.ProductImagePath = filename;
            }

             
            OnlineJewellShop.Entity.Product productMap = AutoMapper.Mapper.Map<ProductModel, Product>(image);
                if (productDetails.UpdateProduct(productMap) > 0)
                {
                    if (image.ImageUpload != null)
                    {
                        filename = Path.Combine(Server.MapPath("~/ProductImages/"), filename);
                        image.ImageUpload.SaveAs(filename);
                    }
                    return RedirectToAction("ViewProduct");
                }
            return View();
        }
        [HttpGet]//getting the delete object from admin
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                Product product = productDetails.GetProduct(id);
                return View(product);
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpPost]//posting to the view
        public ActionResult DeleteProduct(ProductModel products)
        {
            try
            {
                var productMap = AutoMapper.Mapper.Map<ProductModel, Product>(products);
                productDetails.DeleteProduct(productMap);
                return RedirectToAction("ViewProduct");
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }

        }
        [HttpGet]//geting the category from admin
        public ActionResult AddProductCategory()
        {
           
                return View();
            
        }
        [HttpPost]//posting to the view
        public ActionResult AddProductCategory(ProductCatogeryModel productCategoryModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                        string filename = Path.GetFileNameWithoutExtension(productCategoryModel.ImageUpload.FileName);
                        string extension = Path.GetExtension(productCategoryModel.ImageUpload.FileName);
                        filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                        productCategoryModel.ProductImagePath = filename;
                        OnlineJewellShop.Entity.ProductCatogeries productCategoryMap = AutoMapper.Mapper.Map<ProductCatogeryModel, ProductCatogeries>(productCategoryModel);
                        filename = Path.Combine(Server.MapPath("~/ProductCatogeryImages/"), filename);
                    if (extension == ".jpg" || extension == ".png")
                    {
                        productCategoryModel.ImageUpload.SaveAs(filename);
                        int result=productCategoryDetails.AddProductCategory(productCategoryMap);

                        if (result > 0)
                        {
                            return RedirectToAction("ViewProductCategory");
                        }
                    }
                    else
                    {
                        ViewBag.AddImage = "Selected file is not in the correct format please select image file";

                    }
                    return View();
                      
                }
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }

        }//view the category to the admin
        public ActionResult ViewProductCategory()
        {
            try
            {
                IEnumerable<ProductCatogeries> products = productCategoryDetails.DisplayProduct();
                return View(products);
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpGet]//geting the edit object from admin
        public ActionResult EditProductCategory(int id)
        {
            try
            {
                ProductCatogeries product = productCategoryDetails.GetProduct(id);
                TempData["CatogeryImage"] = product.ProductImagePath;
                return View(product);
                
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpPost]//posting to the view
        public ActionResult EditProductCategory(ProductCatogeryModel productCategoryModel)
        {
            string filename = null;
            string extension;
            try
            {
               
                ViewBag.ProductCategories = new SelectList(productCategoryDetails.DisplayProduct(), "ProductCatogeryId", "productCatogeryName");
                if (productCategoryModel.ImageUpload == null)
                {
                    productCategoryModel.ProductImagePath = Convert.ToString(TempData["CatogeryImage"]);
                }
                else
                {
                    filename = Path.GetFileNameWithoutExtension(productCategoryModel.ImageUpload.FileName);
                    extension = Path.GetExtension(productCategoryModel.ImageUpload.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    productCategoryModel.ProductImagePath = filename;
                }


                OnlineJewellShop.Entity.ProductCatogeries productCategoryMap = AutoMapper.Mapper.Map<ProductCatogeryModel, ProductCatogeries>(productCategoryModel);
                if (productCategoryDetails.UpdateProductCategory(productCategoryMap) > 0)
                {
                    if (productCategoryModel.ImageUpload != null)
                    {
                        filename = Path.Combine(Server.MapPath("~/ProductCatogeryImages/"), filename);
                        productCategoryModel.ImageUpload.SaveAs(filename);
                    }
                    return RedirectToAction("ViewProductCategory");
                }
                return View();
            }
            
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpGet]//getting delete object from admin
        public ActionResult DeleteProductCategory(int id)
        {
            try
            {
                ProductCatogeries product = productCategoryDetails.GetProduct(id);
                return View(product);
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpPost]//posting into the view
        public ActionResult DeleteProductCategory(ProductCatogeryModel products)
        {
            try
            {
                var productMap = AutoMapper.Mapper.Map<ProductCatogeryModel, ProductCatogeries>(products);
                productCategoryDetails.DeleteProductCategory(productMap);
                return RedirectToAction("ViewProductCategory");
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }

        }
        //view the user details to admin
        public ActionResult ViewUser()
        {
            try
            {
                IEnumerable<User> userDetails = userDetailsBL.DisplayUser();
                return View(userDetails);
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpGet]//getting the edit object from admin
        public ActionResult EditUser(string id)
        {
            try
            {
                User user = userDetailsBL.GetUser(id);
                return View(user);
            }
            catch
            {
                throw new Exception("Somthing Wrong");
            }
        }
        [HttpPost]//posting to the user
        public ActionResult EditUser(User user)
        {
            try
            {
                userDetailsBL.UpdateUser(user);
                return RedirectToAction("ViewUser");
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpGet]//getting the delete object from admin
        public ActionResult DeleteUser(string id)
        {
            try
            {
                User user = userDetailsBL.GetUser(id);
                return View(user);
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        //posting to the view
        [HttpPost]
        public ActionResult DeleteUser(UserEntityModel user)
        {
            try
            {
                var UserMap = AutoMapper.Mapper.Map<UserEntityModel, User>(user);
                userDetailsBL.DeleteUser(UserMap);
                return RedirectToAction("ViewUser");
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
    }


}
