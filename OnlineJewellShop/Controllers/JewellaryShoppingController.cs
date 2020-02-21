using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewellShop.Controllers
{
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
        public ActionResult SignUp(UserEntity userEntity)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Partial()
        {
            return PartialView();
        }
    }
    
}