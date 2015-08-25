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
        // GET: Detinations
        public ActionResult Index()
        {
            var destination = Croisieres.ListeCroisieres();
            return View();// (destination);
        }

        public ActionResult Details(string idCroisiere)
        {
            Croisieres cr = new Croisieres(idCroisiere);
            return View(cr);

        }
                       

        [ChildActionOnly]
        public PartialViewResult AllCroisieres()
        {
            var listeCroisieres = Croisieres.ListeCroisieres();
            return PartialView("_DestinationPanel", listeCroisieres);
        }
    }
}