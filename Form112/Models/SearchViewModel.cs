using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Form112.Models
{
    public class SearchViewModel
    {
        [XmlIgnore]
        public List<Croisieres> Result { get; set; }
        
        [XmlIgnore]
        public Dictionary<string, Dictionary<string, string>> Destination { get; set; }

        public string IdPays { get; set; }

        
        public DateTime _dateDepart;
        public string _stringDateDepart { get; set; }
        
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
                else 
                {
                    _stringDateDepart = value;
                }
            }
        }

        public int IdPortDepart { get; set; }

        public int IdPrix { get; set; }

        public int IdDuree { get; set; }


        [XmlIgnore]
        public List<KeyValuePair<int, string>> ListTranchePrix { get; set; }


        [XmlIgnore]
        public List<KeyValuePair<int, string>> ListTrancheDuree { get; set; }


        [XmlIgnore]
        public List<KeyValuePair<int, string>> Themes { get; set; }

        [XmlIgnore]
        public List<KeyValuePair<int, string>> Ports { get; set; }

        public int IdTheme { get; set; }

        public string XmlSearchViewModel { get; set; }

        public void SerializeSearchViewModel()
        {
            var xmlSerializer = new XmlSerializer(typeof(SearchViewModel));
            var writer = new StringWriter();
            xmlSerializer.Serialize(writer, this);
            XmlSearchViewModel = writer.ToString();
        }

        public static SearchViewModel UnserializeSearchViewModel(string rvms)
        {
            var xmlSerializer = new XmlSerializer(typeof(SearchViewModel));
            var reader = new StringReader(rvms);
            return (SearchViewModel)xmlSerializer.Deserialize(reader);
        }
    }
}