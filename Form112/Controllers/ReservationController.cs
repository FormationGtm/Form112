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
        /// <summary>
        /// La methode qui affiche le formulaire de réservation
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int? id)
        {
            ViewBag.idCroi = id;

            return View();
        }

        /// <summary>
        /// Requête Linq pour récuperer une croisière avec un Id et l'afficher sur une vue partielle
        /// </summary>
        /// <param name="id"></param>
        /// <returns>objet croisière</returns>
        [ChildActionOnly]
        public PartialViewResult DetailCroisiere(int? id)
        {
            var croisiere = db.Croisieres.Find(id);
            return PartialView("_DestinationPanel", croisiere);
        }

        /// <summary>
        /// Valider et enregistrer une réservation si dispo.
        /// </summary>
        /// <param name="rvm"></param>
        /// <returns>Récapitulatif sur la réservation</returns>
        public ActionResult validerReservation(ReservationViewModels rvm)
        {
            if (Croisieres.VerifDisponibilite(rvm.CroisiereChoisi, rvm.NbPlace))
            {
                var utilisateur = db.Utilisateurs.Where(u => u.Id == rvm.IdUser).FirstOrDefault();
                var adresse = new Adresses();
                TryUpdateModel(adresse);
                adresse.SaveAdress();
                utilisateur.Adresses = adresse;
                utilisateur.SaveUserChange(rvm.IdUser);
                var reservation = new Reservations
                {
                    IdCroisiere = rvm.CroisiereChoisi,
                    IdUtilisateur = rvm.IdUser,
                    DateReservation = DateTime.Now,
                    NbPlace = rvm.NbPlace,
                    MoyenPaiement = rvm.MoyenPaiement
                };
                db.SaveChanges();

                return View(db.Croisieres.Find(rvm.CroisiereChoisi));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}