﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBConnection
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SyfModelCon : DbContext
    {
        public SyfModelCon()
            : base("name=SyfModelCon")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Avatar> Avatars { get; set; }
        public virtual DbSet<Avatar_To_ImageUrl> Avatar_To_ImageUrl { get; set; }
        public virtual DbSet<Avatar_To_Tag> Avatar_To_Tag { get; set; }
        public virtual DbSet<ImageUrl> ImageUrls { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }
}
