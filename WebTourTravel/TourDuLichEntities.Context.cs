﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TourDuLichEntities : DbContext
    {
        public TourDuLichEntities()
            : base("name=TourDuLichEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AnhTour> AnhTour { get; set; }
        public virtual DbSet<DiaDiem> DiaDiem { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<HoatDong> HoatDong { get; set; }
        public virtual DbSet<HuongDanVien> HuongDanVien { get; set; }
        public virtual DbSet<LichTrinhTheoNgay> LichTrinhTheoNgay { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<ThongTinKhachHang> ThongTinKhachHang { get; set; }
        public virtual DbSet<ThongTinLuuY> ThongTinLuuY { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<TourMau> TourMau { get; set; }
    }
}