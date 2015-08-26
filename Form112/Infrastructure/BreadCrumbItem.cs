using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Infrastructure
{
    public class BreadCrumbItem
    {
        public string Texte { get; set; }

        public string Route { get; set; }

        public BreadCrumbItem (string texte, string route)
        {
            Texte = texte;
            Route = route;
        }
    }
}