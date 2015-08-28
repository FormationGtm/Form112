using Form112.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Form112.Controllers
{
    public class CompteController : Controller
    {
        // GET: Compte
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Compte/Inscription
        [AllowAnonymous]
        public ActionResult Inscription()
        {
            return View();
        }

        //Post: /Compte/Inscription
         [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Inscription(InscriptionViewModels ivm)
        {
             //To do....
            return null;
        }
    }
}