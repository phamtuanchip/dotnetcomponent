using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC01.Models;
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
            return View();
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Task/Add
        public ActionResult Add()
        {
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
            return View();
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
