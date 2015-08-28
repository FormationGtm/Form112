using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    partial class Croisieres
    {
        
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
        /// 
        /// </summary>
        /// <param name="idCroisiere"></param>
        public  Croisieres(string idCroisiere)
        {
            var crs = new Croisieres(idCroisiere);
            Prix = crs.Prix;
            Photo = crs.Photo;
            DateDepart = crs.DateDepart;
        }
    }
}
