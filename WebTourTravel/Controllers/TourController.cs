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

        public ActionResult DetailTour(string idTour)
        {
            if(idTour==null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            Tour tbTour = tourEntity.Tour.Find(idTour);
            if (tbTour == null)
                return HttpNotFound();
            return View(tbTour);
        }

        /*Pagination*/
        public ActionResult TourDuLich(int page = 1, int pageSize = 9)
        {
            var totalRecords = tourEntity.Tour.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Order the data before applying Skip and Take
            var dataToDisplay = tourEntity.Tour
                                        .OrderBy(t => t.id_tour) // Sắp xếp dữ liệu trước khi sử dụng Skip và Take
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = (page > 1);
            ViewBag.HasNextPage = (page < totalPages);


            return View("Index",dataToDisplay);
        }

        [HttpGet]
        public ActionResult FilterByDepartureDate(DateTime? departureDate, int page = 1, int pageSize = 9)
        {
            var filteredTours = tourEntity.Tour
                .Where(t => t.KhoiHanh >= departureDate)
                .ToList();

            var totalRecords = filteredTours.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Đảm bảo rằng trang hiện tại không vượt quá số trang mới tính được
            if (page > totalPages)
            {
                page = totalPages;
            }

            var dataToDisplay = filteredTours
                .OrderBy(t => t.id_tour)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = (page > 1);
            ViewBag.HasNextPage = (page < totalPages);

            return View("Index", dataToDisplay);
        }
    }
}