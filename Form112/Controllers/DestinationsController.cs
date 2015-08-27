using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Model;
using DataLayer;

namespace Form112.Controllers
{
    public class DestinationsController : Controller
    {
        private Form112Entities db = new Form112Entities();
      
        // GET: Detinations
        public ActionResult Index()
        {
            var destination = Croisieres.ListeCroisieres();
            return View(destination);
        }

        public ActionResult Details(int idCroisiere)
        {            
            var croisiere = db.Croisieres.Find(idCroisiere);
            return View("Details", croisiere);
        }
                       

        [ChildActionOnly]
        public PartialViewResult AllCroisieres(int id)
        {
            var croisiere = db.Croisieres.Find(id);
            return PartialView("_DestinationPanel", croisiere);
        }
        
    }
}