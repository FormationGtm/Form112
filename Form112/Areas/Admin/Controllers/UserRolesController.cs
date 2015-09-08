using DataLayer.Model;
using Form112.Areas.Admin.Models;
using Form112.Infrastructure.Utilitaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form112.Areas.Admin.Controllers
{
    public class UserRolesController : AdminController
    {
        private Form112Entities db = new Form112Entities();

        // GET: Admin/UserRoles
        public ActionResult Index()
        {
            var urvm = new UserRolesViewModel();

            urvm.UserRoles = db.AspNetUsers.OrderBy(u => u.UserName).ToDictionary(r => r, r => r.AspNetRoles.ToDictionary(p => p.Id, p => p.Name));

            return View(urvm);
        }

        public ViewResult AttributeRole(string id)
        {
            var urvm = new UserRolesViewModel();
            urvm.UserName = db.AspNetUsers.Find(id).UserName;
            urvm.IdUser = id;

            urvm.ListRoles = db.AspNetRoles
                .Select(r => new CheckBoxItem() { ItemId = r.Id, ItemLabel = r.Name })
                .ToList();
            return View(urvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AttributeRole(UserRolesViewModel urvm)
        {
            if (ModelState.IsValid)
            {
                var user = db.AspNetUsers.Find(urvm.IdUser);
                foreach (var idr in urvm.SelectedRoles)
                {
                    var role = db.AspNetRoles.Find(idr);
                    user.AspNetRoles.Add(role);

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            urvm.ListRoles = db.AspNetRoles
                .Select(r => new CheckBoxItem() { ItemId = r.Id, ItemLabel = r.Name })
                .ToList();
            return View();
        }


    }
}