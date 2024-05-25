using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTourTravel.Models;

namespace WebTourTravel.Controllers
{
    public class ProfileController : Controller
    {
        private TourDuLichEntities db = new TourDuLichEntities();

        // GET: Profile/History
        public ActionResult History(string idUser)
        {
            if (string.IsNullOrEmpty(idUser))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "Invalid User ID");
            }

            try
            {
                var orderTours = GetOrderTours(idUser);
                return View("History", orderTours);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Log.Error(ex);
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "An error occurred while fetching the tour history.");
            }
        }

        // GET: Profile/ChoXacNhan
        public ActionResult ChoXacNhan(string idUser, int idStatus)
        {
            if (string.IsNullOrEmpty(idUser))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "Invalid User ID");
            }

            try
            {
                var orderTours = GetOrderTours(idUser, idStatus);
                return View("ChoXacNhan", orderTours);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Log.Error(ex);
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "An error occurred while fetching the pending confirmations.");
            }
        }

        // GET: Profile/DaDat
        public ActionResult DaDat(string idUser, int idStatus)
        {
            if (string.IsNullOrEmpty(idUser))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "Invalid User ID");
            }

            try
            {
                var orderTours = GetOrderTours(idUser, idStatus);
                return View("DaDat", orderTours);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Log.Error(ex);
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "An error occurred while fetching the confirmed bookings.");
            }
        }

        private List<ModelOrderTour> GetOrderTours(string idUser, int? idStatus = null)
        {
            var query = from hoadon in db.HoaDon
                        join tour in db.Tour on hoadon.id_tour equals tour.id_tour
                        where hoadon.Gmail.Equals(idUser)
                        select new ModelOrderTour
                        {
                            IdTour = tour.id_tour,
                            TenTour = tour.TenTour,
                            KhoiHanh = tour.KhoiHanh,
                            Avata = tour.Avata,
                            SoLuongHanhKhach = hoadon.SoLuongHanhKhach,
                            Gmail = hoadon.Gmail,
                            TrangThaiDonHang = hoadon.TrangThaiDonHang
                        };

            if (idStatus.HasValue)
            {
                query = query.Where(hoadon => hoadon.TrangThaiDonHang == idStatus.Value);
            }

            return query.ToList();
        }
    }
}