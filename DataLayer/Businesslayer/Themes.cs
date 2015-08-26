using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    partial class Themes
    {
       
        public static List<Themes> ListeThemes()
        {
            var db = new Form112Entities();
            var collection = db.Themes;
            var lt = new List<Themes>();

            foreach (var them in collection)
            {
                lt.Add(new Themes
                {
                    IdTheme=them.IdTheme,
                    Libelle = them.Libelle

                });
            }
            return lt;
        }
    }
}
