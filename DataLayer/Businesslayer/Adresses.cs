using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public partial class Adresses
    {
        
        /// <summary>
        /// Enregistrer une adresse utilisateur si elle n'existe pas dans la base
        /// </summary>
        public void SaveAdress(Form112Entities db)
        {            
            var add = db.Adresses.Where(a => a.Ligne1 == Ligne1 && a.Ligne2 == Ligne2 && a.Ligne3 == Ligne3 && a.CodePostal == CodePostal);
            if (add.Count() == 0)
            {
                var adresse = new Adresses
                {
                    Ligne1 = Ligne1,
                    Ligne2 = Ligne2,
                    Ligne3 = Ligne3,
                    CodePostal = CodePostal,
                    IdPays = "ABW"
                };
                db.Adresses.Add(adresse);
                db.SaveChanges();
            }
        }
    }
}
