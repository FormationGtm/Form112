using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form112.Controllers
{
    public class PaysController : Controller
    {
        // GET: Pays
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult ListePortDestinations(int id)
        {
            var ListePortDestinations = new Form112Entities().Croisieres
             .Where(crs => crs.IdPort == id)
             .ToList();

            return Json(ListePortDestinations, JsonRequestBehavior.AllowGet);
        }
    }
}