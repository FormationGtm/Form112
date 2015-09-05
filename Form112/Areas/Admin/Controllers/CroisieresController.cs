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
        /// <summary>
        /// requête linq recherchant toutes les croisières dans la table Croisieres et leur durée, port, promo et thème par jointure avec les différentes tables.
        /// </summary>
        /// <returns>la liste de toutes les croisières avec leurs détails</returns>
        public ActionResult Index()
        {
            var croisieres = db.Croisieres.Include(c => c.Durees).Include(c => c.Ports).Include(c => c.Promos).Include(c => c.Themes);
            return View(croisieres.ToList());
        }

        // GET: Admin/Croisieres/Details/5
        /// <summary>
        /// recherche la croisière avec son id passé en paramètre
        /// </summary>
        /// <param name="id"></param>
        /// <returns>une croisière si elle existe </returns>
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
        /// <summary>
        /// affiche un formulaire pour entrer les différentes propriétés d'une nouvelle croisière
        /// Les contenus des menus déroulants sont passés par le ViewBag
        /// </summary>
        /// <returns>vue create</returns>
        public ViewResult Create()
        {
            ViewBag.IdDuree = new SelectList(db.Durees, "IdDuree", "NbJours");
            ViewBag.IdPort = new SelectList(db.Ports, "IdPort", "Nom");
            ViewBag.IdPromo = new SelectList(db.Promos, "IdPromo", "Reduction");
            ViewBag.IdTheme = new SelectList(db.Themes, "IdTheme", "Libelle");
            return View();
        }

        // POST: Admin/Croisieres/Create
        /// <summary>
        /// Si les données entrées dans le formulaire ne sont pas valides, la vue create est à nouveau affichée.
        /// Si elles sont valides, une nouvelle croisière est créée et insérée dans la base de données.
        /// Le formulaire offre la possibilité d'ajouter une photo à la croisière.
        /// </summary>
        /// <param name="cvm"></param>
        /// <param name="postedFile"></param>
        /// <returns>la vue index si la création a réussi ou la vue create si elle a échoué</returns>
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
        /// <summary>
        /// recherche et affiche une croisière sélectionnée par son id passé en paramètre 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>croisiereViewModel</returns>
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
        /// <summary>
        /// modifie la croisière sélectionnée par son id avec les données du croisieresViewModel envoyées par le formulaire.
        /// Modification en base de données.
        /// Possibilité de changer ou ajouter une photo.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cvm"></param>
        /// <param name="postedFile"></param>
        /// <returns>la vue index si la modifiction a réussi ou la vue edit si elle a échoué</returns>
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
        /// <summary>
        /// recherche la croisière dont l'id est passé en paramètre par une requête linq.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>lacroisère sélectionnée</returns>
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
        /// <summary>
        /// supprime la croisière identifiée par son id dans la base
        /// </summary>
        /// <param name="id"></param>
        /// <returns>vue index</returns>
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
