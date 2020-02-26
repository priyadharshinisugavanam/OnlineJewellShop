using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using OnlineJewellShop.BL;
using OnlineJewellShop.DAL;
using System.Web.Mvc;

namespace OnlineJewellShop.Controllers
{
    public class JewellaryShoppingController : Controller
    {
        public object UserRepositary { get; private set; }

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
        public ActionResult SignUp(UserDetails userEntity)
        {
            if (ModelState.IsValid)
            {
                User principal = new User();
                principal.SignUp(userEntity);                
                return RedirectToAction("Login");

            }
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
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
    }
    
}