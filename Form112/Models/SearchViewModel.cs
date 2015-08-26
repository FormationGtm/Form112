using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Form112.Models
{
    public class SearchViewModel
    {
        public Dictionary<string, Dictionary<string, string>> Destination { get; set; }
        public string IdPays { get; set; }

        public DateTime _dateDepart;

        public string DateDepart
        {
            get { return _dateDepart.ToString(); }
            set
            {
                string format = "dd/MM/yyyy";
                if (!DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out _dateDepart))
                {
                    _dateDepart = DateTime.Now;
                }
            }
        }

        public int IdPortDepart { get; set; }
        public int PrixMini { get; set; }
        public int PrixMaxi { get; set; }
        public int DureeMini { get; set; }
        public int DureeMaxi { get; set; }
        public List<KeyValuePair<int, string>> Themes { get; set; }
        public int IdTheme { get; set; }





    }
}