using DataLayer.Businesslayer;
using DataLayer.Model;
using Form112.Infrastructure.Utilitaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form112.Areas.Admin.Controllers
{
    public class StatistiquesController : AdminController
    {
        private Form112Entities _db = new Form112Entities();

        public StatistiquesController()
            : base()
        {
            var bc = new BreadCrumbItem("Statistiques", "/Statistiques");
            lbc.Add(bc);
        }

        // GET: Admin/Statistiques
        /// <summary>
        /// Par requête Linq : construit une liste d'objets StatCroisières (objet croisière + nombre de vues) et l'ordonne par nombre de vues descendant
        /// </summary>
        /// <returns>la liste des croisièers associées à leur nombre de vues</returns>
        public ActionResult Index()
        {
            ViewBag.ListeBC = lbc;
            var listVueCroisieres = _db.ProduitTracking
                .GroupBy(m => m.IdProduit)
                .Select(g => new StatCroisieres { Croisiere = _db.Croisieres.Where(c => c.IdCroisiere == g.Key).FirstOrDefault(), NbVues = g.Count() })
                .OrderByDescending(o => o.NbVues)
                .ToList();

            return View(listVueCroisieres);
        }


        public JsonResult NombreVuesParPays()
        {
            var NombreVuesParPays = _db.ProduitTracking
                .Join(_db.Croisieres, pt => pt.IdProduit, p => p.IdCroisiere, (pt, p) => new {pt.DatePT, p.Ports.Pays })
                .GroupBy(x => x.Pays)
                .Select(g => new { g.Key.Nom, NbVis = g.Count() })
                .OrderBy(x => x.NbVis)
                .ToList();

            return Json(NombreVuesParPays, JsonRequestBehavior.AllowGet);
        }
    }
}