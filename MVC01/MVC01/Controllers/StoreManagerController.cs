using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC01.Models;
namespace MVC01.Controllers
{
    public class StoreManagerController : Controller
    {
        private MusicStoreEntities db = new MusicStoreEntities();
        // GET: StoreManager
        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Genre).Include(a => a.Artist);
            return View(albums.ToList());
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