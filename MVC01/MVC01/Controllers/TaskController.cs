using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC01.Models;
using System.Data.Entity;
namespace MVC01.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        MusicStoreEntities db = new MusicStoreEntities();
        // GET: Task
        public ActionResult Index()
        {
           
            return View(db.Tasks.OrderBy(a=> a.RemindDate).ToList());
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {

            return View(db.Tasks.Find(id));
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Task/Add
        public ActionResult Add()
        {

            List<ApplicationUser> users = ApplicationDbContext.Create().Users.ToList();

            ViewBag.Assignee = new SelectList(users, "UserName", "UserName");
            return View();
        }
        // POST: Task/Add
        [HttpPost]
        public ActionResult Add(ReminderTask task)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Tasks.Add(task);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            List<ApplicationUser> users = ApplicationDbContext.Create().Users.ToList();
            ViewBag.Assignee = new SelectList(users, "UserName", "UserName");
            return View();
        }


        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Tasks.Find(id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ReminderTask reminder)
        {
            try
            {
                db.Entry(reminder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(db.Tasks.Find(id));
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {

            try
            {
                ReminderTask t = db.Tasks.Find(id);
                db.Entry(t).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
