using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC01.Models;

namespace MVC01.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        // GET: Store
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();

            return View(genres);
        }
        public String Browse(String genre) {
            String meg = HttpUtility.HtmlEncode("Hello from store.browser=" + genre);
            return meg;
        }
        public ActionResult Details(int id) {
            var album = new Album { Title = "Album " + id };
            return View(album); 
        }
    }
}