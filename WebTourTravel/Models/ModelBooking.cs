using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTourTravel.Models
{
    public class ModelBooking
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string GhiChu { get; set; }
        public string PhuongThucThanhToan { get; set; }

        public string IdTour { get; set; }
        public double TongTien { get; set; }

        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }

    }
}