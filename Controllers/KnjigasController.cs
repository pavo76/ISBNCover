using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISBNCover.Models;

namespace ISBNCover.Controllers
{
    public class KnjigasController : Controller
    {
        private KnjigaDBContext db = new KnjigaDBContext();

        // GET: Knjigas//Index/0
        public ActionResult Index(int id)
        {
            ViewBag.CurrentPage = id;
            List<Knjiga> Knjige = db.Knjige.ToList();
            List<Knjiga> KnjigeKonacno = Knjige.GetRange(id * 20, 20);
            return View(KnjigeKonacno);
        }

        // GET: Knjigas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiga knjiga = db.Knjige.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }

        // GET: Knjigas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Knjigas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ISBN")] Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                db.Knjige.Add(knjiga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(knjiga);
        }

        // GET: Knjigas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiga knjiga = db.Knjige.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }

        // POST: Knjigas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ISBN")] Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knjiga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(knjiga);
        }

        // GET: Knjigas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiga knjiga = db.Knjige.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }

        // POST: Knjigas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Knjiga knjiga = db.Knjige.Find(id);
            db.Knjige.Remove(knjiga);
            db.SaveChanges();
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
