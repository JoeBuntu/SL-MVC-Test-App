using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocketLabs.TestApp.Domain.Abstract;

namespace SocketLabs.TestApp.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }
 
        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }
         
    }
}
