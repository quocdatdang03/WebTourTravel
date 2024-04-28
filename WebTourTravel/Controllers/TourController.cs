using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTourTravel.Controllers
{
    public class TourController : Controller
    {
         private TourDuLichEntities tourEntity = new TourDuLichEntities();
        // GET: Tour
        public ActionResult Index()
        {
            var tours = tourEntity.Tour.ToList();
            return View("Index",tours);
        }

        public ActionResult DetailTour(string? idTour)
        {
            if(idTour==null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            Tour tbTour = tourEntity.Tour.Find(idTour);
            if (tbTour == null)
                return HttpNotFound();
            return View(tbTour);
        }

    }
}