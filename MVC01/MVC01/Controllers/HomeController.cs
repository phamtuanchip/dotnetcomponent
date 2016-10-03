using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC01.Hubs;
namespace MVC01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           // MessagesHub.SendMessages("index page","visited"); 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Chat()
        {
            ViewBag.Message = "Your chat page.";

            return View();
        }

        public ActionResult Poc()
        {
            return View();
        }
    }
}