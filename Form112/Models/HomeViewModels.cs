using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Models
{
    /// <summary>
    /// ViewModel qui récupère le Code ISO-2 depuis la carte cliquable pour le fournir à la méthode Pays du HomeController
    /// </summary>
    public class HomeViewModels
    {
        public string PaysChoice { get; set; }
    }
}