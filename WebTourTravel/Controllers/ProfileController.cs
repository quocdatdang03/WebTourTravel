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

        public ActionResult ShowEditAccount()
        {
            return View("ThongTinTaiKhoan");
        }

        // UPDATE THONG TIN TAI KHOAN
        [HttpPost]
        public ActionResult UpdateUserInfo()
        {
            // Lấy dữ liệu từ form
            string idTaiKhoan =Request.Form["Gmail"];
            string name = Request.Form["HoTen"];
            string phoneNumber = Request.Form["SoDienThoai"];
            string idCard = Request.Form["SoTaiKhoan"];
            string address = Request.Form["DiaChi"];


            /*  UserInfo model = new UserInfo
          {
              MaTaiKhoan = idTaiKhoan,
              HoTen = name,
              SoDienThoai = phoneNumber,
              GioiTinh = sex,
              CMND = idCard,
              NgaySinh = dateOfBirth
          };*/


            // Tìm tài khoản trong cơ sở dữ liệu
            var tbTaiKhoan = db.NguoiDung.FirstOrDefault(t => t.Gmail == idTaiKhoan);

            if (tbTaiKhoan != null)
            {
                // Cập nhật thông tin của tài khoản
                tbTaiKhoan.HoTen = name;
                tbTaiKhoan.SDT = phoneNumber;
                tbTaiKhoan.STK = idCard;
                tbTaiKhoan.DiaChi = address;

                try
                {
                    // Lưu các thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();
                    return RedirectToAction("History", new { idUser = idTaiKhoan });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Lỗi khi lưu dữ liệu: " + ex.Message);
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Không tìm thấy tài khoản có gmail " + idTaiKhoan);
                return View();
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
                            TrangThaiDonHang = hoadon.TrangThaiDonHang,
                            TongTien = hoadon.TongTien
                        };

            if (idStatus.HasValue)
            {
                query = query.Where(hoadon => hoadon.TrangThaiDonHang == idStatus.Value);
            }

            return query.ToList();
        }
    }
}