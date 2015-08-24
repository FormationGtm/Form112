
using DataLayer.Model;
using Form112.Infrastructure.SearchCroisiers;
using Form112.Infrastructure.SearchCroisiers.Base;
using Form112.Infrastructure.SearchCroisiers.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form112.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        //Recherche avec options 
        private static List<Croisieres> GetSearchResult(SearchViewModele searchViewModele)
        {
            SearchBase search = new Search();


            search = new SearchOptionDureeDeSejour(search, searchViewModele.Duree);

            search = new SearchOptionDateDepart(search, searchViewModele.DateDepart);

            search = new SearchOptionBudget(search, searchViewModele.Budget);

            search = new SearchOptionDestination(search, searchViewModele.Destenation);

            search = new SearchOptionDureeDeSejour(search, searchViewModele.Duree);


            return search.GetResult().ToList();
        }
    }
}