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
    public class HomeController : Controller
    {

        Form112Entities db = new Form112Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private static List<Croisieres> GetPaysResult(HomeViewModels homeViewModel)
        {
            SearchBase search = new Search();
            search = new SearchOptionPays(search, homeViewModel.PaysChoice);
            return search.GetResult().ToList();
        }

        [HttpPost]
        public ActionResult Pays(HomeViewModels hvm)
        {
        return View(GetPaysResult(hvm));
        }

        [ChildActionOnly]
        public PartialViewResult TopSixCroisieres(int idCroisiere)
        {
            var croisiere = db.Croisieres.Find(idCroisiere);
            return PartialView("_DestinationPanel", croisiere);
        }

    }
}