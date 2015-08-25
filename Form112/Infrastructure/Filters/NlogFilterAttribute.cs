using System;
using DataLayer.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
<<<<<<< HEAD
using DataLayer.Model;
using DataLayer;
=======
using System.Web;
>>>>>>> origin/master


namespace Form112.Infrastructure.Filters
{
    public class NlogFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
<<<<<<< HEAD
            var db = new Form112Entities();
            var la = new LogAction
            {
                DateNlog = DateTime.Now,
                Action = filterContext.ActionDescriptor.ActionName,
                Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,                
            };
            db.LogAction.Add(la);
=======
            Form112Entities db = new Form112Entities();
            //var la = new LogAction
            //{
            //    DateNlog = DateTime.Now,
            //    Action = filterContext.ActionDescriptor.ActionName,
            //    Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,                
            //};
            //db.LogAction.Add(la);
>>>>>>> origin/master
            db.SaveChanges();
        }
    }
}