using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Model;
using System.Web.Mvc;
using Form112.Areas.Admin.Models;
using System.Net;
using System.Data.Entity;

namespace Form112.Areas.Admin.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private Form112Entities db = new Form112Entities();
        // GET: Admin/Roles
        /// <summary>
        /// requête linq pour récupérer les rôles d'utilisateurs
        /// </summary>
        /// <returns>liste des rôles dans la vue index</returns>
        public ActionResult Index()
        {
            var roles = db.AspNetRoles.OrderBy(r => r.Id);
            return View(roles.ToList());
        }

        // GET: Admin/Roles/Create
        /// <summary>
        /// affiche le formulaire de création de rôle
        /// </summary>
        /// <returns>la vue create</returns>
        public ViewResult Create()
        {
            return View();
        }

        // POST: Admin/Roles/Create
        /// <summary>
        /// creer un nouveau role s'il est valide et l'integre dans la table
        /// </summary>
        /// <param name="rvm"></param>
        /// <returns>retourne la vue index si la création est réussie sinon le formulaire de création</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RolesViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                AspNetRoles role = new AspNetRoles()
                {
                    Id = rvm.IdRole,
                    Name = rvm.Role
                };
                db.AspNetRoles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Admin/Roles/Edit/5
        /// <summary>
        /// Par une requête linq, recherche le rôle dont l'id est passé en paramètre 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>le RolesViewModel à la vue Edit</returns>
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRoles role = db.AspNetRoles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }

            RolesViewModel rvm = new RolesViewModel()
            {
                IdRole = id,
                Role = role.Name
            };
            return View(rvm);
        }

        // POST: Admin/Roles/Edit/5
        /// <summary>
        /// Si le formulaire est valide, le rôle est modifié avec les donnees entrées.
        /// Les modifications sont sauvegardees dans la base.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rvm"></param>
        /// <returns>retourne la vue index si la modification est réussie sinon la vue edit</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, RolesViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                AspNetRoles role = db.AspNetRoles.Find(id);
                role.Id = rvm.IdRole;
                role.Name = rvm.Role;
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Admin/Roles/Delete/5
        /// <summary>
        /// affiche le rôle désigné par l'id passé en paramètre
        /// </summary>
        /// <param name="id"></param>
        /// <returns>le rôle à la vue delete</returns>
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRoles role = db.AspNetRoles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Admin/Roles/Delete/5
        /// <summary>
        /// confirmation de la suppression
        /// </summary>
        /// <param name="id"></param>
        /// <returns>vue index</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetRoles role = db.AspNetRoles.Find(id);
            db.AspNetRoles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}