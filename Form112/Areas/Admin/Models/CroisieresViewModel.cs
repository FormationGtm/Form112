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
        [Required(ErrorMessage = "obligatoire"), DisplayName("Thème")]
        public int IdTheme { get; set; }
        [Required(ErrorMessage = "obligatoire"), DisplayName("Durée (en jours)")]
        public int IdDuree { get; set; }
        [DisplayName("Promo (en %)")]
        public int IdPromo { get; set; }
        [Required(ErrorMessage = "obligatoire")]
        public int Prix { get; set; }
        [Required(ErrorMessage = "obligatoire"), DisplayName("Port de départ")]
        public int IdPort { get; set; }
        [Required(ErrorMessage = "obligatoire"), DisplayName("Date de départ")]
        public string DateDepart { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }

    }
}