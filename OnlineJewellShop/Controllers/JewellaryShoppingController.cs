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
    public class JewellaryShoppingController : Controller
    {
        UserDetails userDetails = new UserDetails();
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
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserEntityModel userEntity)
        {
            if (ModelState.IsValid)
            {
                userDetails.userID = userEntity.userID;
                userDetails.password = userEntity.password;
                userDetails.phoneNumber = userEntity.phoneNumber;
                userDetails.conformPassword = userEntity.conformPassword;
                userDetails.mailId = userEntity.mailId;
                userDetails.Role = "User";
                User principal = new User();
                principal.SignUp(userDetails);                
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
            if(ModelState.IsValid)
            {
                User user = new User();
                userDetails.userID = loginModel.userID;
                userDetails.password = loginModel.password;
                string role = user.Login(userDetails);
                if (role=="User")
                {
                    return RedirectToAction("Index");
                }
                else if(role=="Admin")
                {
                    return RedirectToAction("SignUp");
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
    }
    
}