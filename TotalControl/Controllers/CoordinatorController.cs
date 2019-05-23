using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotalControl.Models;

namespace TotalControl.Controllers
{
    [Authorize(Roles = "Coordinator")]
    public class CoordinatorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Coordinator
        public ActionResult Index()
        {
            return View();
        }

        // GET: Coordinator/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Coordinator/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: Coordinator/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Phone,")] Coordinator coordinator)        
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

        // GET: Coordinator/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Coordinator/Edit/5
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

        // GET: Coordinator/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Coordinator/Delete/5
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
