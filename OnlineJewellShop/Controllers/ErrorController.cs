using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewellShop.Controllers
{
    public class ErrorController : Controller
    {
        //not found exception
        public ActionResult NotFound()
        {
            return View();
        }
        //overall error
        public ActionResult Error()
        {
            return View();
        }
        //if the mail id is not un
        public ActionResult NotUnique()
        {
            return View();
        }
    }
}