
using DataLayer.Model;
using Form112.Infrastructure.SearchCroisiers;
using Form112.Infrastructure.SearchCroisiers.Base;
using Form112.Infrastructure.SearchCroisiers.Option;
using Form112.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form112.Controllers
{
    public class SearchController : Controller
    {
        Form112Entities db = new Form112Entities();
        // GET: Search
        
        public PartialViewResult Index()
        {
            var svm = new SearchViewModel();
            
            svm.Destination = db.Regions.OrderBy(r => r.Nom).ToDictionary(r => r.Nom, r => r.Pays.ToDictionary(p => p.CodeIso3, p => p.Nom));

            return PartialView("_Index",svm);
        }
        
        //retourne liste des ports
        public JsonResult GetJSONPort(string id)
        {
            var listePorts = db.Ports.Where(p => p.CodeIso3 == id).Select(p => new { IdPort = p.IdPort, Nom = p.Nom }).ToList();
            return Json(listePorts, JsonRequestBehavior.AllowGet);
        }

        //Recherche avec options 
        private static List<Croisieres> GetSearchResult(SearchViewModel searchViewModel)
        {
            SearchBase search = new Search();


            search = new SearchOptionDureeMini(search, searchViewModel.DureeMini);
            search = new SearchOptionDureeMaxi(search, searchViewModel.DureeMaxi);
            search = new SearchOptionDateDepart(search, searchViewModel.DateDepart);
            search = new SearchOptionPrixMini(search, searchViewModel.PrixMini);
            search = new SearchOptionPrixMaxi(search, searchViewModel.PrixMaxi);
            search = new SearchOptionDestination(search, searchViewModel.IdPays);
            search = new SearchOptionPortDepart(search, searchViewModel.IdPortDepart);

            return search.GetResult().ToList();
        }
        [HttpPost]
        public ActionResult Result(SearchViewModel svm)
        {
            return View(GetSearchResult(svm));
        }
    }
}