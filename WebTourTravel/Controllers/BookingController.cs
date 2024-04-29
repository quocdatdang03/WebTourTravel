using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTourTravel.Controllers
{
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
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }
    }
}