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
        /// <summary>
        /// Requête Linq pour obtenir la liste des thèmes existants en base de données.
        /// </summary>
        /// <returns>Une liste de thèmes</returns>
        public ActionResult Index()
        {
            var listeThemes = db.Themes.ToList();
            return View(listeThemes);
        }

        /// <summary>
        /// Requête Linq permettant de fournir une croisière en fonction de son id à la vue partielle _DestinationPanel pour affichage dans la vue Index 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>une vue partielle</returns>
        [ChildActionOnly]
        public PartialViewResult CroisieresParTheme(int id)
        {
            var croisiere = db.Croisieres.Find(id);
            return PartialView("_DestinationPanel", croisiere);
        }

    }
}



