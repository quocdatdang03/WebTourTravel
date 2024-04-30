using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebTourTravel.Helper
{
    public static class  Helper
    {


        public static int CaculateCustomer(TourDuLichEntities tourDuLichEntities , string idtour)
        {
            var maxCus = tourDuLichEntities.Tour.ToList().FirstOrDefault(x=>x.id_tour ==idtour).SoLuongToiDa;
            var hoadons = tourDuLichEntities.HoaDon.Where(x=>x.id_tour == idtour).ToList();
            var quantity = 0;
            foreach(var hoadon  in hoadons)
            {
                quantity += hoadon.SoLuongHanhKhach.Value;
            }    
            return maxCus-quantity;
            
        }
    }
}