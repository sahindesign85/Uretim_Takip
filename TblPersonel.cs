//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Üretimtakip
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblPersonel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblPersonel()
        {
            this.TblGorevler = new HashSet<TblGorevler>();
            this.TblGorevler1 = new HashSet<TblGorevler>();
            this.TblSatinalmaTeklif = new HashSet<TblSatinalmaTeklif>();
            this.TblUrunRecetesi = new HashSet<TblUrunRecetesi>();
            this.TblUrunRecetesi1 = new HashSet<TblUrunRecetesi>();
        }
    
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Görsel { get; set; }
        public Nullable<int> Departman { get; set; }
        public Nullable<bool> Durum { get; set; }
    
        public virtual TblDepartmanlar TblDepartmanlar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblGorevler> TblGorevler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblGorevler> TblGorevler1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSatinalmaTeklif> TblSatinalmaTeklif { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblUrunRecetesi> TblUrunRecetesi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblUrunRecetesi> TblUrunRecetesi1 { get; set; }
    }
}
