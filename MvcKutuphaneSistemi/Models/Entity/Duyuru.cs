//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Duyuru
    {
        public byte DuyuruID { get; set; }
        public string DuyuruKategori { get; set; }
        public string DuyuruIcerik { get; set; }
        public Nullable<System.DateTime> DuyuruTarih { get; set; }
        public Nullable<bool> DuyuruDurum { get; set; }
    }
}
