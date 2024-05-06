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
        public static int[] HelperGetDateValueCategory(int value)
        {
            var listDate = new List<int>();
            switch(value)
            {
                case 0:
                    listDate.Add(0);
                    listDate.Add(100);
                    break;
                case 1:
                    listDate.Add(1);
                    listDate.Add(3);
                    break;
                case 2:
                    listDate.Add(4);
                    listDate.Add(7);
                    break;
                case 3:
                    listDate.Add(8);
                    listDate.Add(14);
                    break;
                case 4:
                    listDate.Add(14);
                    listDate.Add(100);
                    break;
                    
            }
            return listDate.ToArray();
        }
        public static int[] GetCatagoryCustomer(int value)
        {

            var listCus = new List<int>();
            switch (value)
            {
                case 0:
                    listCus.Add(0);
                    listCus.Add(0);
                    break;
                case 1:
                    listCus.Add(1);
                    listCus.Add(2);
                    break;
                case 2:
                    listCus.Add(3);
                    listCus.Add(4);
                    break;
                case 3:
                    listCus.Add(5);
                    listCus.Add(6);
                    break;
                case 4:
                    listCus.Add(6);
                    listCus.Add(100);
                    break;
            }
            return listCus.ToArray();
        }


        public static int GetNumberInString(string chuoi)
        {
            for (int i = 0; i < chuoi.Length; i++)
            {
                if (char.IsDigit(chuoi[i]) )
                {
                    var number = Convert.ToInt32(chuoi[i] + "");
                    return number;
                }
            }
           return 0;
        }
    }
}