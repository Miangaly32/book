﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Book.Models;
using Book.Services;

namespace Book.Controllers
{
    public class HomeController : Controller
    {
        private bookEntities1 db = new bookEntities1();
        LivreService livreService = new LivreService();

        public ActionResult Index()
        {
            if (Session["NomUtilisateur"]!=null)
            {
                Utilisateur u = new Utilisateur
                {
                    NomUtilisateur = Session["NomUtilisateur"].ToString()
                };
                ViewData["Message"] = u;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }           
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public ActionResult Login(Utilisateur objUser)
        {

             var obj = db.Utilisateurs.Where(a => a.NomUtilisateur.Equals(objUser.NomUtilisateur) && a.MotDePasse.Equals(objUser.MotDePasse)).FirstOrDefault();

            if (obj != null)
            {
                Session["IdUtilisateur"] = obj.Id.ToString();
                Session["NomUtilisateur"] = obj.NomUtilisateur.ToString();
                return RedirectToAction("Index");
            }
            return View(objUser);
        }

        public ActionResult Accueil()
        {

            var livres = livreService.GetAllLivres();
         //   var livres = db.Livres.Include(l => l.Auteur).Include(l => l.Genre);
            return View(livres.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
  
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}