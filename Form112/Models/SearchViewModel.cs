using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Models
{
    public class SearchViewModel
    {
        public Dictionary<string, Dictionary<string, string>> Destination { get; set; }
        public string IdPays { get; set; }
        public DateTime DateDepart { get; set; }
        public int IdPortDepart { get; set; }
        public int PrixMini { get; set; }
        public int PrixMaxi { get; set; }
        public int DureeMini { get; set; }
        public int DureeMaxi { get; set; }
   
    }
}