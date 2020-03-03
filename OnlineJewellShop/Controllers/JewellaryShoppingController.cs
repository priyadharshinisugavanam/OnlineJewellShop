using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using OnlineJewellShop.BL;
using OnlineJewellShop.DAL;
using System.Web.Mvc;
using OnlineJewellShop.Models;
using AutoMapper;

namespace OnlineJewellShop.Controllers
{
    //[HandleError ]
    public class JewellaryShoppingController : Controller
    {
       
        
        // GET: JewellaryShopping
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserEntityModel userEntity)
        {
            if (ModelState.IsValid)
            {
                var user = AutoMapper.Mapper.Map<UserEntityModel, UserDetails>(userEntity);
                //UserDetails userDetails = new UserDetails();
                //userDetails.UserID = userEntity.UserID;
                //userDetails.Password = userEntity.Password; 
                //userDetails.phoneNumber = userEntity.PhoneNumber;
                //userDetails.ConformPassword = userEntity.ConformPassword;
                //userDetails.MailId = userEntity.MailId;

                User principal = new User();
                principal.SignUp(user);
                return RedirectToAction("Login");

            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                UserDetails userDetails = new UserDetails();
                User user = new User();
                var login = AutoMapper.Mapper.Map<LoginModel, UserDetails>(loginModel);
                //userDetails.UserID = loginModel.UserID;
                //userDetails.Password = loginModel.Password;
                string role = user.Login(login);
                if (role == "User")
                {
                    return RedirectToAction("Index");
                }
                else if (role == "Admin")
                {
                    return RedirectToAction("AdminOperation");
                }
                else
                {
                    return RedirectToAction("NotFound", "Error");
                }
            }
            return View();
        }
        public ActionResult Partial()
        {

            return PartialView();
        }
        public ActionResult List()
        {
            UserRepositary userRepositary = new UserRepositary();
            IEnumerable<UserDetails> users = userRepositary.Lists();
            return View();
        }
        public ActionResult ProductList()
        {
            ProductRepositary productRepositary = new ProductRepositary();
            IEnumerable<Product> users = productRepositary.List();
            return View();
        }
        public ActionResult AdminAction()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductModel productModel)
        {
            Product product = new Product();
            var productMap = AutoMapper.Mapper.Map<ProductModel, Product>(productModel);
            ProductDetails productDetails = new ProductDetails();
            productDetails.AddProduct(productMap);
            return RedirectToAction("ViewProduct");

        }
        public ActionResult ViewProduct()
        {
            ProductDetails productDetails = new ProductDetails();
            IEnumerable<Product> products = productDetails.DisplayProduct();
            return View(products);
        }
        public ActionResult AdminOperation()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            try
            {
                ProductRepositary productRepositary = new ProductRepositary();
                Product product = productRepositary.GetProduct(id);
                return View(product);
            }
            catch
            {
                throw new Exception("Somthing Wrong");
            }
        }
        [HttpPost]
        public ActionResult EditProduct(ProductModel products)
        {
            try
            {
                Product product = new Product();
                var productMap = AutoMapper.Mapper.Map<ProductModel, Product>(products);
                ProductDetails productDetails = new ProductDetails();
                productDetails.UpdateProduct(productMap);
                return RedirectToAction("ViewProduct");
            }
            catch
            {
                throw new Exception("Something wrong");
            }

        }
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            ProductRepositary productRepositary = new ProductRepositary();
            Product product = productRepositary.GetProduct(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult DeleteProduct(ProductModel products)
        {
            Product product = new Product();
            var productMap = AutoMapper.Mapper.Map<ProductModel, Product>(products);
            ProductDetails productDetails = new ProductDetails();
            productDetails.DeleteProduct(productMap);
            return RedirectToAction("ViewProduct");

        }
        public ActionResult Error()
        {
            return View();
        }
    
    }
    
}