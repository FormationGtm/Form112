using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    /// <summary>
    /// Enregestrement de l'adresse de l'utilisateur
    /// </summary>
    public partial class Utilisateurs
    {
        public void SaveUserChange(Form112Entities db,string id)
        {
            var utilisateur = db.Utilisateurs.Where(u => u.Id == id).FirstOrDefault();
            Adresses = db.Adresses.FirstOrDefault(a => a.Ligne1 == Adresses.Ligne1 && a.Ligne2 == Adresses.Ligne2 && a.Ligne3 == Adresses.Ligne3 && a.CodePostal == Adresses.CodePostal);
            utilisateur.IdAdresse = Adresses.IdAdresse;
            db.SaveChanges();
        }
    }
}
