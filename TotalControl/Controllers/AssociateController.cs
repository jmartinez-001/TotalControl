﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotalControl.Models;

namespace TotalControl.Controllers
{
    [Authorize(Roles = "Associate")]
    public class AssociateController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Associate
        public ActionResult Index()
        {
            return View();
        }

        // GET: Associate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Associate/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: Associate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Phone")] Associate associate)
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

        // GET: Associate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Associate/Edit/5
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

        // GET: Associate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Associate/Delete/5
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
