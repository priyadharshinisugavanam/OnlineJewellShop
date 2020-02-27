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
        public ActionResult SignUp(UserEntityModel userEntity)
        {
            UserDetails userDetails = new UserDetails();
            if (ModelState.IsValid)
            {
                userDetails.userID = userEntity.userID;
                userDetails.password = userEntity.password;
                userDetails.phoneNumber = userEntity.phoneNumber;
                userDetails.conformPassword = userEntity.conformPassword;
                userDetails.mailId = userEntity.mailId;
                userDetails.Role = userEntity.Role;
                User principal = new User();
                principal.SignUp(userDetails);                
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
        public ActionResult List()
        {
            UserRepositary userRepositary = new UserRepositary();
           IEnumerable<UserDetails> users = userRepositary.Lists();
            return View();
        }
    }
    
}