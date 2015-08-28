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
            var listeThemes = db.Themes.ToList();
            return View(listeThemes);
        }

        [ChildActionOnly]
        public PartialViewResult CroisieresParTheme(int id)
        {
            var croisiere = db.Croisieres.Find(id);
            return PartialView("_DestinationPanel", croisiere);
        }

    }
}



