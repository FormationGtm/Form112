using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Form112.Areas.Admin.Models
{
    public class CroisieresViewModel
    {
        [Required, DisplayName("Thème")]
        public int IdTheme { get; set; }
        [Required, DisplayName("Durée (en jours)")]
        public int IdDuree { get; set; }
        [Required, DisplayName("Promo (en %)")]
        public int IdPromo { get; set; }
        [Required]
        public int Prix { get; set; }
        [Required, DisplayName("Port de départ")]
        public int IdPort { get; set; }
        [Required, DataType("date"), DisplayName("Date de départ")]
        public string DateDepart { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
    }
}