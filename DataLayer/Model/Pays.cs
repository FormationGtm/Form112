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
    
    public partial class Pays
    {
        public Pays()
        {
            this.Adresses = new HashSet<Adresses>();
            this.Ports = new HashSet<Ports>();
        }
    
        public string CodeIso3 { get; set; }
        public string CodeIso2 { get; set; }
        public int IdRegion { get; set; }
        public string Nom { get; set; }
    
        public virtual ICollection<Adresses> Adresses { get; set; }
        public virtual Regions Regions { get; set; }
        public virtual ICollection<Ports> Ports { get; set; }
    }
}
