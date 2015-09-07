using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    partial class Croisieres
    {
        private static Form112Entities db = new Form112Entities();
        /// <summary>
        ///Recupérer la liste de toute les croisières
        /// </summary>
        /// <returns></returns>
        public static List<Croisieres> ListeCroisieres()
        {
            var db = new Form112Entities();
            var collection = db.Croisieres;
            var lc = new List<Croisieres>();

            foreach (var crois in collection)
            {
                lc.Add(new Croisieres
                {
                    Prix = crois.Prix,
                    Photo = crois.Photo,
                    DateDepart = crois.DateDepart,
                    IdCroisiere = crois.IdCroisiere
                });             
            }
            return lc;
        }

        /// <summary>
        /// Vérification de nb de place disponible
        /// </summary>
        /// <param name="idCroisiere"></param>
        /// <param name="nbPlace"></param>
        /// <returns>true si oui si non false</returns>
        public static Boolean VerifDisponibilite(int idCroisiere, int nbPlace)
        {
            var capacite = db.Croisieres.Find(idCroisiere).Capacite;
            if(capacite >= nbPlace)
            {
                capacite = capacite - nbPlace;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
