using Form112.Infrastructure.Utilitaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form112.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public List<BreadCrumbItem> lbc { get; set; }
        public AdminController()
        {
            lbc=new List<BreadCrumbItem>();
            var bc = new BreadCrumbItem("Home","/Home");
            lbc.Add(bc);
            
        }
    }
}