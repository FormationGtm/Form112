using System.Linq;
using System.Web.Mvc;
using DataLayer.Model;
using Form112.Models;
using Form112.Infrastructure.Filters;
using System;

namespace Form112.Controllers
{
    public class DestinationsController : Controller
    {
        private static Form112Entities _db = new Form112Entities();

        // GET: Detinations
        public ActionResult Index()
        {
            var destinations = _db.Croisieres.ToList();
            return View(destinations);
        }

        public ActionResult Details(int id)
        {
            Croisieres crs = _db.Croisieres.Find(id);
            return View(crs);
        }

        [ProduitTrackerFilter]
        [HttpPost]
        public ActionResult Details(DestinationViewModel dvm)
        {
            var crs = _db.Croisieres.Find(dvm.DestinationChoice);
            return View(crs);
        }

        [HttpPost]
        public ActionResult Commenter(DetailViewModel detailvm)
        {
            var nouveauCommentaire = new Commentaires
            {
                NomCommentaire = detailvm.NomCommentaire,
                IdCroisiere = detailvm.CroisiereId,
                DateCommentaire = DateTime.Now,
                IdReponseA = detailvm.CommentaireId,
                Commentaire = detailvm.Commentaire
            };

            _db.Commentaires.Add(nouveauCommentaire);
            _db.SaveChanges();

            return RedirectToAction("Details", new { id = detailvm.CroisiereId, controller = "Destinations" });
        }
                      
        [ChildActionOnly]
        public PartialViewResult AllCroisieres(int id)
        {
            var croisiere = _db.Croisieres.Find(id);
            return PartialView("_DestinationPanel", croisiere);
        }
    }
}