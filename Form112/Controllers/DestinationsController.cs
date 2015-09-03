using System.Linq;
using System.Web.Mvc;
using DataLayer.Model;
using Form112.Models;
using Form112.Infrastructure.Filters;

namespace Form112.Controllers
{
    public class DestinationsController : Controller
    {
        private static Form112Entities db = new Form112Entities();

        // GET: Detinations
        public ActionResult Index()
        {
            var destinations = db.Croisieres.ToList();
            return View(destinations);
        }

        [ProduitTrackerFilter]
        [HttpPost]
        public ActionResult Details(DestinationViewModel dvm)
        {
            var crs = db.Croisieres.Find(dvm.DestinationChoice);
            return View(crs);
        }
                       
        [ChildActionOnly]
        public PartialViewResult AllCroisieres(int id)
        {
            var croisiere = db.Croisieres.Find(id);
            return PartialView("_DestinationPanel", croisiere);
        }
    }
}