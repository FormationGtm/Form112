using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public partial class Adresses
    {
        private Form112Entities db = new Form112Entities();
        public void SaveAdress()
        {
            //Est ce que cette adesse exite déja ??
            var add = db.Adresses.Where(a => a.Ligne1 == Ligne1 && a.Ligne2 == Ligne2 && a.Ligne3 == Ligne3 && a.CodePostal == CodePostal);
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
