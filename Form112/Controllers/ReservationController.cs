using DataLayer.Model;
using Form112.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form112.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private Form112Entities db = new Form112Entities();
        // GET: Reservation
        public ActionResult Index(ReservationViewModels rvm)
        {
            var crs = db.Croisieres.Find(rvm.DestinationChoice);

            if(ModelState.IsValid)
            {
                var utilisateur = db.Utilisateurs.Find();
                    utilisateur.IdCroisiere = rvm.DestinationChoice;
                

                
            }
            return View(crs);
        }

        [ChildActionOnly]
        public PartialViewResult DetailCroisiere(int id)
        {
            var croisiere = db.Croisieres.Find(id);
            return PartialView("_DestinationPanel", croisiere);
        }
    }
}