//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ports
    {
        public Ports()
        {
            this.Croisieres = new HashSet<Croisieres>();
        }
    
        public int IdPort { get; set; }
        public string IdPays { get; set; }
        public string Nom { get; set; }
    
        public virtual ICollection<Croisieres> Croisieres { get; set; }
        public virtual Pays Pays { get; set; }
    }
}
