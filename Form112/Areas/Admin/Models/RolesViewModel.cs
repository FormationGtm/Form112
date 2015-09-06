using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Form112.Areas.Admin.Models
{
    public class RolesViewModel
    {
        [Required(ErrorMessage = "obligatoire"), MaxLength(256, ErrorMessage = "La longueur maximale est de 256 caractères")]
        public string Role { get; set; }
        [Required(ErrorMessage = "obligatoire"), MaxLength(128, ErrorMessage = "La longueur maximale est de 128 caractères")]
        public string IdRole { get; set; }
    }
}