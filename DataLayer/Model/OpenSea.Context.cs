﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Form112Entities : DbContext
    {
        public Form112Entities()
            : base("name=Form112Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Croisieres> Croisieres { get; set; }
        public virtual DbSet<Durees> Durees { get; set; }
        public virtual DbSet<Pays> Pays { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Ports> Ports { get; set; }
        public virtual DbSet<Promos> Promos { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Themes> Themes { get; set; }
    }
}
