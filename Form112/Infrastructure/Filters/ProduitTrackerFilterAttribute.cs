using DataLayer.Model;
using Form112.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form112.Infrastructure.Filters
{
    public class ProduitTrackerFilterAttribute: ActionFilterAttribute
    {
        private static Form112Entities _db = new Form112Entities();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ap = filterContext.ActionParameters.First();

            var prodTrack = new ProduitTracking();
            prodTrack.DatePT = DateTime.Now;
            prodTrack.IdProduit = ((DestinationViewModel)ap.Value).DestinationChoice;

            _db.ProduitTracking.Add(prodTrack);
            _db.SaveChanges();
        }
    }
}