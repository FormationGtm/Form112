using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form112.Controllers
{
    public class PromotionsController : Controller
    {
        private Form112Entities db = new Form112Entities();
        
        // GET: Promotions
        /// <summary>
        /// Requête Linq pour fournir la liste des croisières ayant une promotion en cours.
        /// </summary>
        /// <returns>Liste de croisières</returns>
        public ActionResult Index()
        {
            var croisieres = new List<Croisieres>();
            croisieres = db.Croisieres.Where(c => c.IdPromo.HasValue).ToList();
            return View(croisieres);
        }

        /// <summary>
        /// Requête Linq permettant de fournir une croisière en fonction de son id à la vue partielle _DestinationPanel pour affichage dans la vue Index 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>une vue partielle</returns>
        [ChildActionOnly]
        public PartialViewResult AllPromotions(int id)
        {
            var croisieres = db.Croisieres.Find(id);
            return PartialView("_DestinationPanel", croisieres);
        }

        /// <summary>
        /// Une reqête Linq pour récuperer les 5 croisières dont la réduction plus élevée et les affichés sur une vue partielle
        /// </summary>
        /// <returns>liste d'objets croisière</returns>
        [ChildActionOnly]
        public PartialViewResult TopPromo()
        {
            var croisiere = new List<Croisieres>();
            croisiere = db.Croisieres.Where(c => c.IdPromo.HasValue).OrderByDescending(c => c.Promos.Reduction).Take(5).ToList();
            return PartialView("_TopPromoPanel", croisiere);
        }
    }
}