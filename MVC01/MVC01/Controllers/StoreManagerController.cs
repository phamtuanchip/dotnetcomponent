using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC01.Models;
using PagedList;
namespace MVC01.Controllers
{
    public class StoreManagerController : Controller
    {
        private MusicStoreEntities db = MusicStoreEntities.Instance();
        // GET: StoreManager
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.NameSortParm = sortOrder != "name_desc" ? "name_desc" : "name";
            ViewBag.TitleSortParm = sortOrder != "title_desc" ? "title_desc" : "title";
            ViewBag.PriceSortParm = sortOrder != "price_desc" ? "price_desc" : "price";
            ViewBag.CurrentSort = sortOrder;
            var albums = db.Albums.Include(a => a.Genre).Include(a => a.Artist);
            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                albums = albums.Where(s => s.Title.Contains(searchString));

            }
            albums = albums.OrderBy(s => s.Genre.Name);
            switch (sortOrder)
            {
                case "name_desc":
                    albums = albums.OrderByDescending(s => s.Artist.Name);
                    break;
                case "title_desc":
                    albums = albums.OrderByDescending(s => s.Title);
                    break;

                case "name":
                    albums = albums.OrderBy(s => s.Artist.Name);
                    break;
                case "title":
                    albums = albums.OrderBy(s => s.Title);
                    break;

                case "price":
                    albums = albums.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    albums = albums.OrderByDescending(s => s.Price);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(albums.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(int id)
        {
            Album album = db.Albums.Find(id);
            return View(album);
        }

        public ActionResult Create()
        {

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return View();
        }

        public ActionResult Edit(int id)
        {
            Album album = db.Albums.Find(id);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                //db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        public ActionResult Delete(int id) {
            Album album = db.Albums.Find(id);
            return View(album);
        }
        /**
        [HttpPost]
        public ActionResult Delete(Album album) {

            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Deleted;
                //db.Albums.Add(album);
                db.Albums.Remove(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }
    **/

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id) { Album album = db.Albums.Find(id); db.Albums.Remove(album); db.SaveChanges(); return RedirectToAction("Index"); }
    }
}