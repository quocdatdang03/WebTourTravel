using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebTourTravel.Help;
using WebTourTravel.Models;
using WebTourTravel.Help;

namespace WebTourTravel.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        TourDuLichEntities tourEntity = new TourDuLichEntities();
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Booking(string idTour)
        {
            if (idTour == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Tour tour = tourEntity.Tour.Find(idTour);
            var soLuongCon = Helper.Helper.CaculateCustomer(tourEntity, idTour);
            ModelInfoBooking modelInfoBooking = new ModelInfoBooking(tour,soLuongCon);
            if (tour == null)
            {
                return HttpNotFound();
            }
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string Email = ticket.Name;
           
            var ten = HelpCustommners.GetNguoiDungByEmail(Email);
            ViewBag.UserName = ten.Gmail;
            return View(modelInfoBooking);
        }
    }
}