using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataLayer.Model;
using DataLayer;


namespace Form112.Infrastructure.Filters
{
    public class NlogFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var db = new Form112Entities();
            var la = new LogAction
            {
                DateNlog = DateTime.Now,
                Action = filterContext.ActionDescriptor.ActionName,
                Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,                
            };
            db.LogAction.Add(la);
            db.SaveChanges();
        }
    }
}