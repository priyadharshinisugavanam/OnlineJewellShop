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
    public class HomeController : Controller
    {
        // GET: Home


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
        
}