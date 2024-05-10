using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebTourTravel.Models;
using WebTourTravel.Help;

namespace WebTourTravel.Controllers
{
    public class PaymentController : Controller
    {
        [HttpPost]
        public ActionResult Index()
        {
            // Lấy dữ liệu từ form
            string name = Request.Form["Name"];
            string email = Request.Form["Email"];
            string phoneNumber = Request.Form["PhoneNumber"];
            string ghiChu = Request.Form["GhiChu"];
            string paymentMethod = Request.Form["PhuongThucThanhToan"];
            int slNguoiLon = int.Parse(Request.Form["SoLuongNguoiLon"]);
            int slTreEm = int.Parse(Request.Form["SoLuongTreEm"]);

            string idTour = Request.Form["IdTour"];

            double tongTien = double.Parse(Request.Form["TongTien"]);


            // Map dữ liệu vào model
            ModelBooking model = new ModelBooking
            {
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber,
                GhiChu = ghiChu,
                SoLuongNguoiLon = slNguoiLon,
                SoLuongTreEm = slTreEm,
                PhuongThucThanhToan = paymentMethod,
                IdTour = idTour,
                TongTien = tongTien
            };

            return View(model);
        }
        public ActionResult PayBank()
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string Email = ticket.Name;

            var ten = HelpCustommners.GetNguoiDungByEmail(Email);
            ViewBag.UserName = ten.Gmail;
            return View();
        }
        public ActionResult PayMomo()
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string Email = ticket.Name;

            var ten = HelpCustommners.GetNguoiDungByEmail(Email);
            ViewBag.UserName = ten.Gmail;
            return View();
        }
        public ActionResult PayZalo()
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string Email = ticket.Name;

            var ten = HelpCustommners.GetNguoiDungByEmail(Email);
            ViewBag.UserName = ten.Gmail;
            return View();
        }
    }
}