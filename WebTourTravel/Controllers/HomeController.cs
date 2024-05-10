using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTourTravel.Controllers
{
    public class HomeController : Controller
    {
        private TourDuLichEntities tourEntity = new TourDuLichEntities();
        public ActionResult Index() { 
            var tours = tourEntity.Tour.Take(3).ToList();
            return View(tours);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}