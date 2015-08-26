using DataLayer.Model;
using Form112.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form112.Controllers
{
    public class ThemesController : Controller
    {
        private Form112Entities db = new Form112Entities();

        // GET: Themes
        public ActionResult Index()
        {
             var listeThemes = Themes.ListeThemes();
            return View (listeThemes);
        }

        public ActionResult Details(string idCroisiere)
        {
            Croisieres crois = new Croisieres(idCroisiere);
            return View (crois);
        }

        public PartialViewResult CroisieresParTheme(int id)
        {
            var listeCroisieres = new List<Croisieres>();
            listeCroisieres = db.Croisieres.Where(c => c.IdTheme == id).ToList();
            return PartialView("_ThemePanel", listeCroisieres);
        }

    }
}

//var db = new Form112Entities();
//            var tvm = new ThemeViewModels();
//            tvm.ThemesCroisieres = db.Themes.OrderBy(t=>t.Nom)
//                .ToDictionary(t=>t.Nom, r=>r.Croisieres.OrderBy(c=>c.DateDepart))
//                .ToDictionary(c=>c.)