using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Form112.Areas.Admin.Models
{
    public class MailingViewModel
    {
        
        [Required, Display(Name = "Sujet")]
        public string Sujet { get; set; }

        [Required, Display(Name = "Votre message")]
        public string Message { get; set; }
    }
}