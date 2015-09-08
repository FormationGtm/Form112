using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataLayer.Model;
using DataLayer.Businesslayer;

namespace Form112.Controllers
{
    public class CroisieresApiController : ApiController
    {
        private Form112Entities db = new Form112Entities();

        // GET: api/CroisieresApi
        //public IQueryable<Croisieres> GetCroisieres()
        //{
        //    return db.Croisieres;
        //}

        // GET: api/CroisieresApi/5
        [ResponseType(typeof(Croisieres))]
        public IHttpActionResult GetCroisieres()
        {
            Croisieres croisieres = db.Croisieres.Find(2);
            if (croisieres == null)
            {
                return NotFound();
            }

            var cApi = new CroisiereAPI();

            cApi.Titre = "Croisière OpenSea au Venezuela";
            cApi.Localisation = croisieres.Ports.Nom;
            cApi.Description = croisieres.Description;
            cApi.Prix = croisieres.Prix.ToString() + " € moins 60% de reduction";
            cApi.Image = "http://form112.dlucazeau.fr/Uploads/Bateaux/Carnival_Elation_croisiere_a_rabais.jpg";
            cApi.URL = "http://form112.dlucazeau.fr/Destinations/Details/2";
            

            return Ok(cApi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CroisieresExists(int id)
        {
            return db.Croisieres.Count(e => e.IdCroisiere == id) > 0;
        }
    }
}