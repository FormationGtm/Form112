using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Form112.Infrastructure.SearchCroisiers;
using Form112.Infrastructure.SearchCroisiers.Base;
using Form112.Infrastructure.SearchCroisiers.Option;
using DataLayer.Model;
using Form112.Models;

namespace Form112.Controllers
{
    public class DestinationsController : Controller
    {

        private static Form112Entities db = new Form112Entities();

        // GET: Detinations
        public ActionResult Index()
        {
            var destination = Croisieres.ListeCroisieres();
            return View();// (destination);
        }

        [HttpPost]
        public ActionResult Details(DestinationViewModel dvm)
        {
            var crs = db.Croisieres.Find(dvm.DestinationChoice);
            return View(crs);
        }
                       
        [ChildActionOnly]
        public PartialViewResult AllCroisieres()
        {
            var listeCroisieres = Croisieres.ListeCroisieres();
            return PartialView("_DestinationPanel", listeCroisieres);
        }
    }
}