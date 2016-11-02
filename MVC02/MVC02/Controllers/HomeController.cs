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
        public ActionResult Search()
        {
            ViewBag.Message = "Your contact page.";
            List<String> term = new List<string>();
            ViewBag.Message = "Your display page.";
            for (var i = 0; i <= 8000; i++)
            {

                var id = "ppoisi.16." + i;
                term.Add(id);
            }
            ViewBag.items = term;
            return View();
        }
        public ActionResult DisplayData() {
            List<String> term = new List<string>();
            ViewBag.Message = "Your display page.";
            for (var i = 0; i <= 8000; i++)
            {

                var id = "ppoisi.16." + i;
                term.Add(id);
            }
            ViewBag.items = term;
            return View();
        }
        public class MissionData {
        public    String id;
            public String value;
            public String label;
            public DateTime lastDay;
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult searchMissionIndex(List<String> ids) {
            List<MissionData> data = new List<MissionData>();
            List<String> term = new List<string>();
            var array = new int[] { 1, 2, 3, 4 };
           
                for (var i = 0; i <= 10000; i++) {
                
                var sid = "ppoisi.16." + i;
                foreach (char c in "abcdefghiklmnopqrstuvwxyz"){
                    data.Add(new MissionData { label = sid + ".a" + c, value = sid + ".a" + c + i, id = sid, lastDay = new DateTime() });
                }
                
                
            }
            IEnumerable<MissionData> searchData = new List<MissionData>();
            if (ids != null) {
             searchData = data.Where(d => ids.Contains(d.id)).Select(m => new MissionData {label = m.label,value = m.id, id = m.id, lastDay = m.lastDay });
            }
            return Json(searchData, JsonRequestBehavior.AllowGet);
        }
    }
}
