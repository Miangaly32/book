using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Book.Models;

namespace Book.Controllers
{
    public class LivresController : Controller
    {
        private bookEntities db = new bookEntities();

        // GET: Livres
        public ActionResult Index()
        {
            var livres = db.Livres.Include(l => l.Auteur).Include(l => l.Genre);
            return View(livres.ToList());
        }

        // GET: Livres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = db.Livres.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            return View(livre);
        }

        // GET: Livres/Create
        public ActionResult Create()
        {
            ViewBag.IdAuteur = new SelectList(db.Auteurs, "Id", "Nom");
            ViewBag.IdGenre = new SelectList(db.Genres, "Id", "Designation");
            return View();
        }

        // POST: Livres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titre,Description,DateSortie,IdAuteur,IdGenre")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                db.Livres.Add(livre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAuteur = new SelectList(db.Auteurs, "Id", "Nom", livre.IdAuteur);
            ViewBag.IdGenre = new SelectList(db.Genres, "Id", "Designation", livre.IdGenre);
            return View(livre);
        }

        // GET: Livres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = db.Livres.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAuteur = new SelectList(db.Auteurs, "Id", "Nom", livre.IdAuteur);
            ViewBag.IdGenre = new SelectList(db.Genres, "Id", "Designation", livre.IdGenre);
            return View(livre);
        }

        // POST: Livres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titre,Description,DateSortie,IdAuteur,IdGenre")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAuteur = new SelectList(db.Auteurs, "Id", "Nom", livre.IdAuteur);
            ViewBag.IdGenre = new SelectList(db.Genres, "Id", "Designation", livre.IdGenre);
            return View(livre);
        }

        // GET: Livres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = db.Livres.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            return View(livre);
        }

        // POST: Livres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livre livre = db.Livres.Find(id);
            db.Livres.Remove(livre);
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
