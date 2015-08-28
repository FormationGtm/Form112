using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form112.Controllers
{
    public class PromotionsController : Controller
    {
        private Form112Entities db = new Form112Entities();
        // GET: Promotions
        public ActionResult Index()
        {
            var croisieres = new List<Croisieres>();
            croisieres = db.Croisieres.Where(c => c.IdPromo.HasValue).ToList();
            return View(croisieres);
        }

        [ChildActionOnly]
        public PartialViewResult AllPromotions(int id)
        {
            var croisieres = db.Croisieres.Find(id);
            return PartialView("_DestinationPanel", croisieres);
        }
    }
}