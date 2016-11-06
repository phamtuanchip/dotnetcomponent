using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using Microsoft.VisualBasic.FileIO;
using MVC02.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
        public ActionResult ReadCSVFile() {
            Dictionary<int, String[]> term = new Dictionary<int, string[]>();
            ViewBag.Data = term;
            using (TextFieldParser parser = new TextFieldParser(@"c:\temp\test.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                int i = 0;
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    term.Add(i, fields);
                    foreach (string field in fields)
                    {
                        //TODO: Process field
                    }
                    i++;
                }
            }
            return View();
        }
        public ActionResult ConnectLDAPServer()
        {
            try
            {
                var searchString = "test";
                DirectoryEntry rootEntry = new DirectoryEntry("LDAP://localhost");
                rootEntry.AuthenticationType = AuthenticationTypes.None; //Or whatever it need be
                DirectorySearcher searcher = new DirectorySearcher(rootEntry);
                var queryFormat = "(&(objectClass=user)(objectCategory=person)(|(SAMAccountName=*{0}*)(cn=*{0}*)(gn=*{0}*)(sn=*{0}*)(email=*{0}*)))";
                searcher.Filter = string.Format(queryFormat, searchString);
                foreach (SearchResult result in searcher.FindAll())
                {
                    Console.WriteLine("account name: {0}", result.Properties["samaccountname"].Count > 0 ? result.Properties["samaccountname"][0] : string.Empty);
                    Console.WriteLine("common name: {0}", result.Properties["cn"].Count > 0 ? result.Properties["cn"][0] : string.Empty);
                }
            }
            catch (Exception e) {
                ViewBag.ErrorMsg = "Connection LDAP error: " + e.Message;
            }
            return View();
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
        [System.Web.Mvc.HttpGet]
        public ActionResult upLoadFile() {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult upLoadFile(HttpPostedFileBase file) {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                file.SaveAs(path);
                ViewBag.msg = "file saved " + path;
                ViewBag.filePath = path;
            }

            return View();
        }

        public ActionResult Download(string virtualFilePath)
        {
            
            return File(virtualFilePath, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(virtualFilePath));
        }

        
    }
}
