using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form112.Controllers
{
    public class PaysController : Controller
    {
        // GET: Pays
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Méthode pour obtenir la liste des croisères d'un des ports de départ du pays sélectioné.
        /// Utilisé pour un affichage dynamique par JavaScript ŝur la même par en fonction du port sélectionné
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Liste de croisières en JSON</returns>
        public JsonResult ListePortDestinations(int id)
        {
            var ListePortDestinations = new Form112Entities().Croisieres
             .Where(crs => crs.IdPort == id)
             .ToList();

            return Json(ListePortDestinations, JsonRequestBehavior.AllowGet);
        }
    }
}