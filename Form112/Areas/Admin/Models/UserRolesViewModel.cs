using DataLayer.Model;
using Form112.Infrastructure.Utilitaires;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Form112.Areas.Admin.Models
{
    public class UserRolesViewModel
    {
        public Dictionary<AspNetUsers, Dictionary<string, string>> UserRoles { get; set; }
        public string IdUser { get; set; }
        public string UserName { get; set; }
        public List<CheckBoxItem> ListRoles { get; set; }
        [Display(Name = "Rôles")]
        public string[] SelectedRoles { get; set; }

    }
}