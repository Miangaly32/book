﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Book.Models;
using System.Diagnostics;
using PagedList;

namespace Book.Controllers
{
    public class AuteursController : Controller
    {
        private bookEntities1 db = new bookEntities1();

        // GET: Auteurs
        public ActionResult Index(int? id)
        {
            Auteur_List liste_Auteur = new Auteur_List();
            liste_Auteur.auteurTab = db.Auteurs.ToList();
            if (id == null || id == -1)
            {
                liste_Auteur.auteurPage = db.Auteurs.ToList();
                return View(liste_Auteur);
            }                        
            Auteur auteur = db.Auteurs.Find(id);
            if(auteur == null)
            {
                return HttpNotFound();
            }
            liste_Auteur.auteurPage = new List<Auteur>(1);
            liste_Auteur.auteurPage.Add(auteur);
            return View(liste_Auteur);
        }

        // GET: Auteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Auteur");
            }
            Auteur auteur = db.Auteurs.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // GET: Auteurs/Create
        [Authorize]
        public ActionResult Create()
        {
            List<Auteur> allAuteur = db.Auteurs.ToList();
            ViewBag.auteur = allAuteur;
            return View("Create");
        }

        // POST: Auteurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom")] Auteur auteur)
        {
            if (ModelState.IsValid)
            {
                db.Auteurs.Add(auteur);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(auteur);
        }

        // GET: Auteurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.Auteurs.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // POST: Auteurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom")] Auteur auteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(auteur);
        }

        // GET: Auteurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.Auteurs.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // POST: Auteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auteur auteur = db.Auteurs.Find(id);
            db.Auteurs.Remove(auteur);
            db.SaveChanges();
            return RedirectToAction("Create");
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
