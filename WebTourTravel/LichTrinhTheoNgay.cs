//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebTourTravel
{
    using System;
    using System.Collections.Generic;
    
    public partial class LichTrinhTheoNgay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LichTrinhTheoNgay()
        {
            this.HoatDong = new HashSet<HoatDong>();
        }
    
        public string id_lichtrinh { get; set; }
        public string id_tourmau { get; set; }
        public string TenLichTrinh { get; set; }
        public string SoLuongNgay { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoatDong> HoatDong { get; set; }
        public virtual TourMau TourMau { get; set; }
    }
}
