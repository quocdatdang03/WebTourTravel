using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTourTravel.Models;
using WebTourTravel.Help;
using System.Web.Security;

namespace WebTourTravel.Help
{
    public static  class HelpCustommners
    {
        public static bool  IsEmailExits(List<NguoiDung> nguoiDungs , string email)
        {
            bool result = nguoiDungs.FirstOrDefault(x => x.Gmail.Equals(email)) != null;
            return result ;
        }
        public  static NguoiDung LoginCheck( List<NguoiDung> nguoiDungs,string gmail , string passworld)
        {
             var nd = nguoiDungs.FirstOrDefault(x => x.Gmail.Equals(gmail) && x.MatKhau.Equals(passworld));
            return nd;
        }


        public static NguoiDung GetNguoiDungByEmail(string email)
        {
            TourDuLichEntities tour = new TourDuLichEntities();
            var listND = tour.NguoiDung.ToList();
            return listND.FirstOrDefault(x => x.Gmail.Equals(email));
        }
           

       /* public static  NguoiDung GetNDInCookie()
        {
            string cookieName = FormsAuthentication.FormsCookieName; 
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); 
            string Email = ticket.Name;
            return GetNguoiDungByEmail(Email);
        }*/
    }
}