using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Model;
using Form112.Infrastructure.SearchCroisiers.Option;
using Form112.Infrastructure.SearchCroisiers.Base;
using Form112.Infrastructure.SearchCroisiers;
using Form112.Models;

namespace Form112.Controllers
{
    public class HomeController : Controller
    {

        private static Form112Entities db = new Form112Entities();

        public ActionResult Index()
        {
            var listCroisieres = db.Croisieres.ToList();
            return View(listCroisieres);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Méthode qui construit la liste des ports pour un pays donné.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>une liste JSON</returns>
        public JsonResult ListePortDestinations(int id)
        {
            var listePortDestinations = db.Croisieres
                .Where(crs => crs.IdPort == id)
                .Select(crs => new
                {
                    idCrs = crs.IdCroisiere,
                    PaysName = crs.Ports.Pays.Nom,
                    Prix = crs.Prix,
                    Photo = crs.Photos.FirstOrDefault(),
                    Reduc = crs.Promos.Reduction
                })
                .ToList();

            return Json(listePortDestinations, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Méthode pour filter les destinations à partir de la sélection d'un pays (HomeViewModel) sur la carte du monde.
        /// </summary>
        /// <param name="homeViewModel"></param>
        /// <returns>Liste des croisières d'un pays</returns>
        private static List<Croisieres> GetPaysResult(HomeViewModels homeViewModel)
        {
            SearchBase search = new Search();
            search = new SearchOptionPays(search, homeViewModel.PaysChoice);
            return search.GetResult().ToList();
        }

        /// <summary>
        /// Méthode d'appel de la méthode privée GetPaysResult qui récupère le HomeViewModel au click sur la carte et lui transmet. 
        /// </summary>
        /// <param name="hvm"></param>
        /// <returns>Liste des croisières d'un pays donné</returns>
        [HttpPost]
        public ActionResult Pays(HomeViewModels hvm)
        {
            return View(GetPaysResult(hvm));
        }

        public JsonResult ListPaysCroisieres()
        {
            var listPaysCroisieres = db.Croisieres.Select(crs => new { codeIso2 = crs.Ports.Pays.CodeIso2 }).ToList();

            return Json(listPaysCroisieres, JsonRequestBehavior.AllowGet);
        }
    }
}