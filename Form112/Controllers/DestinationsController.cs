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
        /// <summary>
        /// Requête Linq : fournit la liste de toutes les croisières présentent en base 
        /// </summary>
        /// <returns>Liste de croisières à la vue index destination.</returns>
        public ActionResult Index()
        {
            var destinations = _db.Croisieres.ToList();
            return View(destinations);
        }

        /// <summary>
        /// Requête Linq : va chercher une croisière en particulier à partir de son id
        /// Méthode utilisée pour rester sur la page de détail d'une croisière après commentaire
        /// </summary>
        /// <param name="id"></param>
        /// <returns>un objet croisière</returns>
        public ActionResult Details(int id)
        {
            Croisieres crs = _db.Croisieres.Find(id);
            return View(crs);
        }


        /// <summary>
        /// Requête Linq : fournit une croisière spécifique à partir de son id quand on clique sur la vue partielle d'une croisière. 
        /// Porte le filtre de comptage de vue
        /// </summary>
        /// <param name="dvm"></param>
        /// <returns>un objet croisière</returns>
        [ProduitTrackerFilter]
        [HttpPost]
        public ActionResult Details(DestinationViewModel dvm)
        {
            var crs = _db.Croisieres.Find(dvm.DestinationChoice);
            return View(crs);
        }

        /// <summary>
        /// Créer un objet commentaire et le sauvegarde dans la base de donnée à partir d'un DetailViewModel.
        /// La soumission renvoit sur la page actuelle.
        /// </summary>
        /// <param name="detailvm"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Méthode appelée pour l'affichage d'une croisière dans sa forme vue partielle.
        /// Requête Linq : fournit à la vue partielle la croisière à partir de son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>une vue partielle _DestinationPanel</returns>
        [ChildActionOnly]
        public PartialViewResult AllCroisieres(int id)
        {
            var croisiere = _db.Croisieres.Find(id);
            return PartialView("_DestinationPanel", croisiere);
        }

        /// <summary>
        /// Méthode d'affichage des commentaires d'une croisière à partir de l'id du commentaire.
        /// Requête Linq pour fournir le commentaire spécifique
        /// </summary>
        /// <param name="id"></param>
        /// <returns>une vue partielle _CommentairePanel</returns>
        public PartialViewResult AfficherCommentaire(int id){
            var commentaire = _db.Commentaires.Find(id);
            return PartialView("_CommentairePanel", commentaire);
        }
    }
}