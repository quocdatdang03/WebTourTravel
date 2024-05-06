using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebTourTravel.Help
{
    public static class SearchTourHelper
    {


        public static   List<Tour> HardSearch( TourDuLichEntities tourDuLichEntities ,DateTime? ngaydi , int? quantityDate, int? quantitiCus)
        {
            if (ngaydi == null) ngaydi = DateTime.Now;
            var cusdata = quantityDate == null ? 0 : quantitiCus.Value;
            var datedata = quantitiCus == null ? 0 : quantityDate.Value;
            var cus = Helper.Helper.GetCatagoryCustomer(cusdata);
            var date = Helper.Helper.HelperGetDateValueCategory(datedata);
            var tourgets = tourDuLichEntities.Tour
           .Where(t => t.KhoiHanh > ngaydi)
           .ToList();
            var availableTour = new List<Tour>();
           //Add price here
           foreach (var tour in tourgets)
            {
                var quantityleft = Helper.Helper.CaculateCustomer(tourDuLichEntities, tour.id_tour);
                var day = Helper.Helper.GetNumberInString(tour.ThoiGian.Trim());
                if (quantityleft >= cus[1]  && day >= date[0] && day <= date[1])
                {
                    availableTour.Add(tour);   
                }
            }

            return availableTour;
        }


        public static List<Tour> GetTourByLocation(TourDuLichEntities tourDuLichEntities ,string location)
        {
            List<Tour> tours = new List<Tour>();
            List<string> idtourmau = new List<string>();
            var tourmaus = tourDuLichEntities.TourMau.ToList();
            foreach(var tourmau in tourmaus)
            {
                if (location.Equals("Quảng Nam")) location = "Hội An";
                if(tourmau.DiemThamQuan.Contains(location))
                {
                    idtourmau.Add(tourmau.id_tourmau);
                }
            }

            foreach(var tour in tourDuLichEntities.Tour.ToList())
            {
                if(idtourmau.Contains(tour.id_tourmau))
                {
                    tours.Add(tour);
                }
            }
            return tours;
        }

    }
}