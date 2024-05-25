using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTourTravel.Models
{
    public class ModelOrderTour
    {
        public string IdTour { get; set; }
        public string TenTour { get; set; }
        public DateTime KhoiHanh { get; set; }
        public string Avata { get; set; }
        public Nullable<int> SoLuongHanhKhach { get; set; }
        public string Gmail { get; set; }
        public Nullable<int> TrangThaiDonHang { get; set; }
    }
}