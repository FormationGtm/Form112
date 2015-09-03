
using DataLayer.Model;
using Form112.Infrastructure.SearchCroisiers;
using Form112.Infrastructure.SearchCroisiers.Base;
using Form112.Infrastructure.SearchCroisiers.Option;
using Form112.Infrastructure.Utilitaires;
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

        public PartialViewResult Index(string ssvm)
        {
            SearchViewModel svm;
            if (string.IsNullOrEmpty(ssvm))
            {
                svm = new SearchViewModel();
            }
            else
            {
                svm = SearchViewModel.UnserializeSearchViewModel(ssvm);
            }

            svm.Destination = db.Regions.OrderBy(r => r.Nom).ToDictionary(r => r.Nom, r => r.Pays.ToDictionary(p => p.CodeIso3, p => p.Nom));
            svm.Themes = db.Themes.OrderBy(t => t.Libelle).AsEnumerable().Select(t => new KeyValuePair<int, string>(t.IdTheme, t.Libelle)).ToList();
            svm.Ports = db.Ports.OrderBy(t => t.Nom).AsEnumerable().Select(t => new KeyValuePair<int, string>(t.IdPort, t.Nom)).ToList();
            svm.ListTranchePrix = ListesChoix.ListTranchePrix();
            svm.ListTrancheDuree = ListesChoix.ListTrancheDuree();

//#if DEBUG
//            svm.IdPays = "FRA";
//            svm.DateDepart = new DateTime(2016, 1, 1).ToString("dd/MM/yyyy");
//#endif
            return PartialView("_Index", svm);
        }

        [HttpPost]
        public ActionResult Result(SearchViewModel svm)
        {
            svm.SerializeSearchViewModel();
            svm.Result = GetSearchResult(svm);

            //svm._stringDateDepart = new DateTime(2016, 1, 1).ToString("dd/MM/yyyy");
            return View(svm);
        }

        //Recherche avec options 
        private static List<Croisieres> GetSearchResult(SearchViewModel searchViewModel)
        {
            SearchBase search = new Search();

            search = new SearchOptionIdDuree(search, searchViewModel.IdDuree);
            search = new SearchOptionDateDepart(search, searchViewModel._dateDepart);
            search = new SearchOptionIdPrix(search, searchViewModel.IdPrix);
            search = new SearchOptionDestination(search, searchViewModel.IdPays);
            search = new SearchOptionPortDepart(search, searchViewModel.IdPortDepart);
            search = new SearchOptionTheme(search, searchViewModel.IdTheme);

            return search.GetResult().ToList();
        }

        //retourne liste des ports
        public JsonResult GetJSONPort(string id)
        {
            var listePorts = db.Ports.Where(p => p.CodeIso3 == id).Select(p => new { IdPort = p.IdPort, Nom = p.Nom }).ToList();
            return Json(listePorts, JsonRequestBehavior.AllowGet);
        }

    }
}