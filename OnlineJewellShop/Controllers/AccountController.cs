using OnlineJewellShop.BL;
using OnlineJewellShop.DAL;
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
        IUserBL userBL;
        public AccountController()
        {
            accountBL = new AccountBL();
            userBL = new UserBL();
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
            DbConnect dbConnect = new DbConnect();
            try
            {
                if (ModelState.IsValid)
                {
                    if (userEntity.ConformPassword == userEntity.Password )
                    {
                        
                        var mail = dbConnect.Data.Where(x => x.MailId == userEntity.MailId).SingleOrDefault();
                        if (mail == null) { 

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
                            ViewBag.Message = "This mail id is already used";
                        }
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
            return RedirectToAction("Login");
        } 

        //partial view
        public ActionResult Partial()
        {
            
                return PartialView();
           
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            string user = HttpContext.User.Identity.Name;
            User users = userBL.GetMail(user);
            return View(users);

        }
        [HttpPost]
        public ActionResult ChangePassword(User user)
        {
            try
            {
                
                int result=userBL.UpdateUser(user);
                if (result > 0)
                {
                    ViewBag.PasswordChange = "Profile Updated";
                }
                
                return View(user);
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
    }
}
