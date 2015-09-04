using System.Linq;
using System.Web.Mvc;
using DataLayer.Model;
using Form112.Models;
using Form112.Infrastructure.Filters;

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

        [ProduitTrackerFilter]
        [HttpPost]
        public ActionResult Details(DestinationViewModel dvm)
        {
            var utilisteur = _db.Utilisateurs.Find(dvm.DestinationChoice);
            return View();
        }
                       
        [ChildActionOnly]
        public PartialViewResult AllCroisieres(int id)
        {
            var croisiere = _db.Croisieres.Find(id);
            return PartialView("_DestinationPanel", croisiere);
        }
    }
}