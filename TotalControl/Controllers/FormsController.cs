using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TotalControl.Models;

namespace TotalControl.Controllers
{
    public class FormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Forms
        public async Task<ActionResult> Index()
        {
            
            var forms = db.Forms.Include(f => f.Section);
            return View(await forms.ToListAsync());
        }

        // GET: Forms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = await db.Forms.FindAsync(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        // GET: Forms/Create
        public ActionResult Create()
        {
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name");
            return View();
        }

        // POST: Forms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SectionId,Name,DateCreated,DateConducted,PreparedBy,Version,Procedures,CorrectiveAction,ActionsTaken,Comments,Photo,Signature")] Form form)
        {
            if (ModelState.IsValid)
            {
                db.Forms.Add(form);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", form.SectionId);
            return View(form);
        }

        // GET: Forms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = await db.Forms.FindAsync(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", form.SectionId);
            return View(form);
        }

        // POST: Forms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SectionId,Name,DateCreated,DateConducted,PreparedBy,Version,Procedures,CorrectiveAction,ActionsTaken,Comments,Photo,Signature")] Form form)
        {
            if (ModelState.IsValid)
            {
                db.Entry(form).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", form.SectionId);
            return View(form);
        }

        // GET: Forms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = await db.Forms.FindAsync(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        // POST: Forms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Form form = await db.Forms.FindAsync(id);
            db.Forms.Remove(form);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
