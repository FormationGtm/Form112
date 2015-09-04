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
        public ActionResult Index()
        {            
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult DetailCroisiere(int id)
        {
            var croisiere = db.Croisieres.Find(id);            
            return PartialView("_DestinationPanel", croisiere);
        }

        /// <summary>
        /// valider une réservation
        /// </summary>
        /// <param name="rvm"></param>
        /// <returns></returns>
       public ActionResult validerReservation(ReservationViewModels rvm)
        {
            DestinationViewModel dvm = new DestinationViewModel();                                                                
                var utilisateur = db.Utilisateurs.Where(u => u.Id == rvm.IdUser).FirstOrDefault();
                var adress = new Adresses();
                TryUpdateModel(adress);
                adress.SaveAdress();
                var add = db.Adresses.FirstOrDefault();               
                utilisateur.IdAdresse = add.IdAdresse;
               // utilisateur.IdCroisiere = dvm.DestinationChoice;
                db.SaveChanges();

                return View();          
        }
    }
}