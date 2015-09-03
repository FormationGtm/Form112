using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Model;
using System.IO;
using Form112.Areas.Admin.Models;
using System.Globalization;

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
        public ViewResult Create()
        {
            ViewBag.IdDuree = new SelectList(db.Durees, "IdDuree", "NbJours");
            ViewBag.IdPort = new SelectList(db.Ports, "IdPort", "Nom");
            ViewBag.IdPromo = new SelectList(db.Promos, "IdPromo", "Reduction");
            ViewBag.IdTheme = new SelectList(db.Themes, "IdTheme", "Libelle");
            return View();
        }

        // POST: Admin/Croisieres/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CroisieresViewModel cvm, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    var filename = Path.GetFileName(postedFile.FileName);
                    if (filename == null)
                        return RedirectToAction("Create");
                    var path = Path.Combine(Server.MapPath("~/Uploads/Bateaux/"), filename);
                    postedFile.SaveAs(path);
                    cvm.Photo = filename;
                }
                Croisieres crs = new Croisieres()
                {
                    IdTheme = cvm.IdTheme,
                    IdDuree = cvm.IdDuree,
                    IdPromo = cvm.IdPromo,
                    IdPort = cvm.IdPort,
                    Prix = cvm.Prix,
                    DateDepart = DateTime.ParseExact(cvm.DateDepart, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None),
                    Photo = cvm.Photo,
                    Description = cvm.Description

                };
                db.Croisieres.Add(crs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDuree = new SelectList(db.Durees, "IdDuree", "NbJours");
            ViewBag.IdPort = new SelectList(db.Ports, "IdPort", "Nom");
            ViewBag.IdPromo = new SelectList(db.Promos, "IdPromo", "Reduction");
            ViewBag.IdTheme = new SelectList(db.Themes, "IdTheme", "Libelle");
            return View();
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
            CroisieresViewModel cvm = new CroisieresViewModel
            {
                IdTheme = croisieres.IdTheme,
                IdDuree = croisieres.IdDuree,
                IdPromo = (int)croisieres.IdPromo,
                IdPort = croisieres.IdPort,
                Prix = croisieres.Prix,
                DateDepart = croisieres.DateDepart.ToString("dd/MM/yyyy",
                  CultureInfo.InvariantCulture),
                Photo = croisieres.Photo,
                Description = croisieres.Description
            };

            ViewBag.IdDuree = new SelectList(db.Durees, "IdDuree", "NbJours", cvm.IdDuree);
            ViewBag.IdPort = new SelectList(db.Ports, "IdPort", "Nom", cvm.IdPort);
            ViewBag.IdPromo = new SelectList(db.Promos, "IdPromo", "Reduction", cvm.IdPromo);
            ViewBag.IdTheme = new SelectList(db.Themes, "IdTheme", "Libelle", cvm.IdTheme);
            return View(cvm);
        }

        // POST: Admin/Croisieres/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CroisieresViewModel cvm, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    var filename = Path.GetFileName(postedFile.FileName);
                    if (filename == null)
                        return RedirectToAction("Create");
                    var path = Path.Combine(Server.MapPath("~/Uploads/Bateaux/"), filename);
                    postedFile.SaveAs(path);
                    cvm.Photo = filename;
                }
                Croisieres crs = db.Croisieres.Find(id);

                crs.IdTheme = cvm.IdTheme;
                crs.IdDuree = cvm.IdDuree;
                crs.IdPromo = cvm.IdPromo;
                crs.IdPort = cvm.IdPort;
                crs.Prix = cvm.Prix;
                crs.DateDepart = DateTime.ParseExact(cvm.DateDepart, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None);
                crs.Photo = cvm.Photo;
                crs.Description = cvm.Description;

                db.Entry(crs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            Croisieres croisieres = db.Croisieres.Find(id);
            ViewBag.IdDuree = new SelectList(db.Durees, "IdDuree", "NbJours", croisieres.IdDuree);
            ViewBag.IdPort = new SelectList(db.Ports, "IdPort", "Nom", croisieres.IdPort);
            ViewBag.IdPromo = new SelectList(db.Promos, "IdPromo", "Reduction", croisieres.IdPromo);
            ViewBag.IdTheme = new SelectList(db.Themes, "IdTheme", "Libelle", croisieres.IdTheme);
            return View();
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
