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
            return View(destination);// (destination);
        }

        public ActionResult Details(int idCroisiere)
        {
            //Croisieres cr = new Croisieres(idCroisiere);
            //return View(cr);
            var croisiere = db.Croisieres.Find(idCroisiere);//Croisieres.ListeCroisieres();
            return View("Details", croisiere);

        }
                       

        [ChildActionOnly]
        public PartialViewResult AllCroisieres(int id)
        {
            var croisiere = db.Croisieres.Find(id);//Croisieres.ListeCroisieres();
            return PartialView("_DestinationPanel", croisiere);
        }
        
    }
}