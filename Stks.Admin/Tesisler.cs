//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stks.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    public partial class Tesisler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tesisler()
        {
            this.TesisKiralama = new HashSet<TesisKiralama>();
        }
    
        public int Id { get; set; }
        [DisplayName("Tesis Adi")]
        public string tesisAdi { get; set; }
        [DisplayName("Saha Adi")]
        public string sahaAdi { get; set; }
        [DisplayName("Spor Turu")]
        public string sporTuru { get; set; }
        [DisplayName("Il")]
        public string il { get; set; }
        [DisplayName("Ilce")]
        public string ilce { get; set; }
        [DisplayName("Adres")]
        public string adres { get; set; }
        [DisplayName("Telefon Numarasi")]
        public string telNo { get; set; }
        [DisplayName("Servis")]
        public Nullable<bool> servis { get; set; }
        [DisplayName("Resim")]
        public string resim { get; set; }
        [DisplayName("Saat Dilimi")]
        public Nullable<int> saatDilimi { get; set; }
        [DisplayName("Acilis Saati")]
        public Nullable<System.TimeSpan> acilisSaati { get; set; }
        [DisplayName("Kapanis Saati")]
        public Nullable<System.TimeSpan> kapanisSaati { get; set; }
        public Nullable<int> ucret { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TesisKiralama> TesisKiralama { get; set; }
    }
}
