namespace Form112.Areas.Admin.Controllers {
    #region UsingRegion

    using System.Linq;
    using System.Web.Mvc;
    using DataLayer.Businesslayer;
    using DataLayer.Model;
    using Infrastructure.Utilitaires;

    #endregion

    public class StatistiquesController : AdminController {
        private readonly Form112Entities _db = new Form112Entities();

        public StatistiquesController() {
            var bc = new BreadCrumbItem("Statistiques", "/Statistiques");
            lbc.Add(bc);
        }

        // GET: Admin/Statistiques
        /// <summary>
        ///     Par requête Linq : construit une liste d'objets StatCroisières (objet croisière + nombre de vues) et l'ordonne par
        ///     nombre de vues descendant
        /// </summary>
        /// <returns>la liste des croisières associées à leur nombre de vues</returns>
        public ActionResult Index() {
            ViewBag.ListeBC = lbc;
            var listVueCroisieres = _db.ProduitTracking
                .GroupBy(m => m.IdProduit)
                .Select(
                    g =>
                        new StatCroisieres {
                            Croisiere = _db.Croisieres.FirstOrDefault(c => c.IdCroisiere == g.Key),
                            NbVues = g.Count()
                        })
                .OrderByDescending(o => o.NbVues)
                .ToList();

            return View(listVueCroisieres);
        }


        public JsonResult NombreVuesParPays() {
            var nombreVuesParPays = _db.ProduitTracking
                .Join(_db.Croisieres, pt => pt.IdProduit, p => p.IdCroisiere, (pt, p) => new { pt.DatePT, p.Ports.Pays })
                .GroupBy(x => x.Pays)
                .Select(g => new { g.Key.Nom, NbVis = g.Count() })
                .OrderBy(x => x.NbVis)
                .ToList();

            return Json(nombreVuesParPays, JsonRequestBehavior.AllowGet);
        }
    }
}