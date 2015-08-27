using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Model;

namespace Form112.Areas.Admin.Controllers
{
    [Authorize]
    public class CroisieresController : Controller
    {
        private Form112Entities db = new Form112Entities();

        // GET: Admin/Croisieres
        public ActionResult Index()
        {
            var croisieres = db.Croisieres.Include(c => c.Durees).Include(c => c.Ports).Include(c => c.Promos).Include(c => c.Themes);
            return View(croisieres.ToList());
        }

        // GET: Admin/Croisieres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Croisieres croisieres = db.Croisieres.Find(id);
            if (croisieres == null)
            {
                return HttpNotFound();
            }
            return View(croisieres);
        }

        // GET: Admin/Croisieres/Create
        public ActionResult Create()
        {
            ViewBag.IdDuree = new SelectList(db.Durees, "IdDuree", "IdDuree");
            ViewBag.IdPort = new SelectList(db.Ports, "IdPort", "CodeIso3");
            ViewBag.IdPromo = new SelectList(db.Promos, "IdPromo", "IdPromo");
            ViewBag.IdTheme = new SelectList(db.Themes, "IdTheme", "Libelle");
            return View();
        }

        // POST: Admin/Croisieres/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCroisiere,IdTheme,IdDuree,IdPromo,IdPort,Prix,DateDepart,Photo,Description")] Croisieres croisieres)
        {
            if (ModelState.IsValid)
            {
                db.Croisieres.Add(croisieres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDuree = new SelectList(db.Durees, "IdDuree", "IdDuree", croisieres.IdDuree);
            ViewBag.IdPort = new SelectList(db.Ports, "IdPort", "CodeIso3", croisieres.IdPort);
            ViewBag.IdPromo = new SelectList(db.Promos, "IdPromo", "IdPromo", croisieres.IdPromo);
            ViewBag.IdTheme = new SelectList(db.Themes, "IdTheme", "Libelle", croisieres.IdTheme);
            return View(croisieres);
        }

        // GET: Admin/Croisieres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Croisieres croisieres = db.Croisieres.Find(id);
            if (croisieres == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDuree = new SelectList(db.Durees, "IdDuree", "IdDuree", croisieres.IdDuree);
            ViewBag.IdPort = new SelectList(db.Ports, "IdPort", "CodeIso3", croisieres.IdPort);
            ViewBag.IdPromo = new SelectList(db.Promos, "IdPromo", "IdPromo", croisieres.IdPromo);
            ViewBag.IdTheme = new SelectList(db.Themes, "IdTheme", "Libelle", croisieres.IdTheme);
            return View(croisieres);
        }

        // POST: Admin/Croisieres/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCroisiere,IdTheme,IdDuree,IdPromo,IdPort,Prix,DateDepart,Photo,Description")] Croisieres croisieres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(croisieres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDuree = new SelectList(db.Durees, "IdDuree", "IdDuree", croisieres.IdDuree);
            ViewBag.IdPort = new SelectList(db.Ports, "IdPort", "CodeIso3", croisieres.IdPort);
            ViewBag.IdPromo = new SelectList(db.Promos, "IdPromo", "IdPromo", croisieres.IdPromo);
            ViewBag.IdTheme = new SelectList(db.Themes, "IdTheme", "Libelle", croisieres.IdTheme);
            return View(croisieres);
        }

        // GET: Admin/Croisieres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Croisieres croisieres = db.Croisieres.Find(id);
            if (croisieres == null)
            {
                return HttpNotFound();
            }
            return View(croisieres);
        }

        // POST: Admin/Croisieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Croisieres croisieres = db.Croisieres.Find(id);
            db.Croisieres.Remove(croisieres);
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
