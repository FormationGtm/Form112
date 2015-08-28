using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Form112.Models
{
    public class ReservationViewModels
    {
        [Required]
        [Display(Name = "Nom*")]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Prénom*")]
        public string Prenom { get; set; }

        [Required, DisplayName("Adresse ligne1*"), MaxLength(36)]
        public string Ligne1 { get; set; }
        [Required, DisplayName("Adresse ligne2"), MaxLength(36)]
        public string Ligne2 { get; set; }
        [Required, DisplayName("Adresse ligne3"), MaxLength(36)]
        public string Ligne3 { get; set; }
        [Required, DisplayName("Code postal*"), MaxLength(5)]
        public string CodePostal { get; set; }

        [Required, DisplayName("Numéro de la carte*"), StringLength(14)]
        public string NumCart { get; set; }
        [Required, DisplayName("Date de fin*"), StringLength(5)]
        public string DateFin { get; set; }
        [Required, DisplayName("Cryp.*"), StringLength(3)]
        public string Cryp { get; set; }

        public int DestinationChoice { get; set; }
    }
}