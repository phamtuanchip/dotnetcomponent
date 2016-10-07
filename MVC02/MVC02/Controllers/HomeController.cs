using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using MVC02.Models;

namespace MVC02.Controllers
{
    public class HomeController : Controller
    {
         

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
             
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "Your app test page.";
            HomeModelView vm = new HomeModelView();
            return View(vm);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Test(HomeModelView vm)
        {
            ViewBag.Message = "Your app test save page.";
             

            if (ModelState.IsValid)
            {
                
              
                foreach (var day in vm.RangeDays)
                {

                    vm.MapDays.Add(day, day);
                }
                
            }
           

            return View(vm);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
