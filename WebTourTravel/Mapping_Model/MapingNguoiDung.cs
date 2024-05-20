using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTourTravel.Models;


namespace WebTourTravel.Mapping_Model
{
    public static class MapingNguoiDung
    {
       

        public static NguoiDung AccountToNguoiDung (ModelRegister modelLogin)
        {
            var nguoidung = new NguoiDung();
            nguoidung.MatKhau = modelLogin.PassWord;
            nguoidung.Gmail = modelLogin.Email;
            nguoidung.HoTen = "User";
            nguoidung.TenTK = "";
            nguoidung.SDT = "";
            nguoidung.STK = "";
            nguoidung.TrangThai = 1;
            nguoidung.DiaChi = "";
            return nguoidung;
        }
    }
}