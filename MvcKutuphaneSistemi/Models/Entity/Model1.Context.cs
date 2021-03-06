﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphaneSistemi.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MvcKutuphaneEntities : DbContext
    {
        public MvcKutuphaneEntities()
            : base("name=MvcKutuphaneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cezalar> Cezalar { get; set; }
        public virtual DbSet<Hareketler> Hareketler { get; set; }
        public virtual DbSet<Kasa> Kasa { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<Kitaplar> Kitaplar { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Uyeler> Uyeler { get; set; }
        public virtual DbSet<Yazarlar> Yazarlar { get; set; }
        public virtual DbSet<Hakkimizda> Hakkimizda { get; set; }
        public virtual DbSet<iletisim> iletisim { get; set; }
        public virtual DbSet<Mesajlar> Mesajlar { get; set; }
        public virtual DbSet<Duyuru> Duyuru { get; set; }
    
        public virtual ObjectResult<string> EnFazlaKitapYazar()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("EnFazlaKitapYazar");
        }
    
        public virtual ObjectResult<EnBasariliPersonel_Result> EnBasariliPersonel()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EnBasariliPersonel_Result>("EnBasariliPersonel");
        }
    
        public virtual ObjectResult<Nullable<byte>> EnBasariliPersonel2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<byte>>("EnBasariliPersonel2");
        }
    
        public virtual ObjectResult<Nullable<int>> EnAktifUye()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("EnAktifUye");
        }
    
        public virtual ObjectResult<string> EnCokOkunanKitap()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("EnCokOkunanKitap");
        }
    
        public virtual ObjectResult<Nullable<int>> BugunEmanet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("BugunEmanet");
        }
    }
}
