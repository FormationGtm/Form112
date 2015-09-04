using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Models
{
    public class DetailViewModel
    {
        public string NomCommentaire { get; set; }
        public int CroisiereId { get; set; }
        public int? CommentaireId { get; set; }
        public string Commentaire { get; set; }
    }
}