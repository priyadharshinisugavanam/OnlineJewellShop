using OnlineJewellShop.BL;
using OnlineJewellShop.Entity;
using OnlineJewellShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineJewellShop.Controllers
{
    public class AccountController : Controller
    {
        IAccountBL accountBL;
        public AccountController()
        {
            accountBL = new AccountBL();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]//get method for signup
        public ActionResult SignUp()
        {

            return View();

        }
        [HttpPost]//post method for signup
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserEntityModel userEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (userEntity.ConformPassword == userEntity.Password)
                    {
                        var user = AutoMapper.Mapper.Map<UserEntityModel, User>(userEntity);
                        //UserDetails userDetails = new UserDetails();
                        //userDetails.UserID = userEntity.UserID;
                        //userDetails.Password = userEntity.Password; 
                        //userDetails.phoneNumber = userEntity.PhoneNumber;
                        //userDetails.ConformPassword = userEntity.ConformPassword;
                        //userDetails.MailId = userEntity.MailId;


                        accountBL.SignUp(user);
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ViewBag.Message = "Conform password does not match password";
                    }
                }
                return View();
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("NotUnique", "Error");
            }

        }
        [HttpGet]
        //geting the details from user
        public ActionResult Login()
        {
            
                return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//posting into the view
        public ActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var login = AutoMapper.Mapper.Map<LoginModel, User>(loginModel);
                    
                    User user = accountBL.Login(login);

                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.MailId, false);
                        var authTicket = new FormsAuthenticationTicket(1, user.MailId, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Role);
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        HttpContext.Response.Cookies.Add(authCookie);
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ViewBag.message = "UserId or password is wrong";
                    }

                   
                }
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }



        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //partial view
        public ActionResult Partial()
        {
            
                return PartialView();
           
        }



    }
}
