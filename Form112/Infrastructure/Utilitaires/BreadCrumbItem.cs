using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Infrastructure.Utilitaires
{
    public class BreadCrumbItem
    {
        public string Texte { get; set; }
        public string Chemin { get; set; }


        public BreadCrumbItem(string texte, string chemin)
        {
            Texte = texte;
            Chemin = chemin;

        }
    }
}