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
        MusicStoreEntities storeDB = MusicStoreEntities.Instance();
        // GET: Store
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }
        public ActionResult Browse(String genre) {
            if (String.IsNullOrEmpty(genre)) return Index();
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);
            return View(genreModel);
        }

        public ActionResult Details(int id) {

            var album = storeDB.Albums.Find(id);
            return View(album); 
        }
    }
}