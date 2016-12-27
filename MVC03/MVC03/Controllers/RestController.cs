using System;

using System.Web.Http;

using System.Web;
using System.Web.Mvc;


using System.IO;
using System.Web.Http.Results;
using MVC03.Filter;

namespace MVC03.Controllers
{
   
    public class RestController : ApiController
    {
        [System.Web.Http.HttpGet]
        [AllowJsonGet]
        public JsonResult Test() {
            return new JsonResult();
        }

        [System.Web.Http.HttpGet]
        [AllowJsonGet]
        public String Teststring()
        {
            return "test";
        }

        [System.Web.Http.HttpPost]
        public JsonResult Upload(HttpPostedFile file)
        {
            return new JsonResult();
        }

        [System.Web.Http.HttpGet]
        [AllowJsonGet]
        public JsonResult<DirectoryInfo> LoadFolder(String folderName)
        {
            DirectoryInfo di = new DirectoryInfo("C:\\"+ folderName);
            String[] folders = System.IO.Directory.GetDirectories(@"C:\"+ folderName, "*", System.IO.SearchOption.AllDirectories);

            foreach (string f in folders)
            {
                //call some function to get all files in folder
            }
            return Json(di);
        }

        [System.Web.Http.HttpGet]
        [AllowJsonGet]
        public DirectoryInfo LoadRoot(String folderName)
        {
            DirectoryInfo di = new DirectoryInfo("C:\\" + folderName);

            return di;
        }
    }
}
