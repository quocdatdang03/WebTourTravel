﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTourTravel.Models;
using WebTourTravel.Helper;
using WebTourTravel.Help;

namespace WebTourTravel.Controllers
{
    public class TourController : Controller
    {
        private TourDuLichEntities tourEntity = new TourDuLichEntities();

        // GET: Tour
        public ActionResult Index()
        {
            var tours = tourEntity.Tour.ToList();
             return View("Index", tours);
        }


        //Search by location
        public ActionResult FilterLoCation(string idLocation, int page = 1, int pageSize = 9)
        {
            var tours = SearchTourHelper.GetTourByLocation(tourEntity, idLocation);

            var totalRecords = tours.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Đảm bảo rằng trang hiện tại không vượt quá số trang mới tính được
            if (page > totalPages)
            {
                page = totalPages;
            }

            var dataToDisplay = tours
                .OrderBy(t => t.id_tour)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = (page > 1);
            ViewBag.HasNextPage = (page < totalPages);
            return View("Index", tours);
        }

        public ActionResult DetailTour(string idTour)
        {


            var tourDetails = (from tour in tourEntity.Tour
                               join tourMau in tourEntity.TourMau on tour.id_tourmau equals tourMau.id_tourmau
                               join anhTour in tourEntity.AnhTour on tourMau.id_tourmau equals anhTour.id_tourmau
                               where tour.id_tour == idTour
                               select new TourDetailViewModel
                               {
                                   IdTour = tour.id_tour,
                                   IdTourMau = tourMau.id_tourmau,
                                   TenTour = tour.TenTour,
                                   KhoiHanh = tour.KhoiHanh,
                                   NoiKhoiHanh = tour.NoiKhoiHanh,
                                   ThoiGianTour = tour.ThoiGian,
                                   TapTrung = tour.TapTrung,
                                   SoLuongToiDa = tour.SoLuongToiDa,
                                   MoTaTourMau = tourMau.MoTaTourMau,
                                   ThoiGianTourMau = tourMau.ThoiGian,
                                   PhuongTienDiChuyen = tourMau.PhuongTienDiChuyen,
                                   DiemThamQuan = tourMau.DiemThamQuan,
                                   AmThuc = tourMau.AmThuc,
                                   KhachSan = tourMau.KhachSan,
                                   ThoiGianLyTuong = tourMau.ThoiGianLyTuong,
                                   DoiTuongThichHop = tourMau.DoiTuongThichHop,
                                   UuDai = tourMau.UuDai,
                                   DuongDan1 = anhTour.DuongDan1,
                                   DuongDan2 = anhTour.DuongDan2,
                                   DuongDan3 = anhTour.DuongDan3,
                                   DuongDan4 = anhTour.DuongDan4,
                                   DuongDan5 = anhTour.DuongDan5,
                                   DuongDan6 = anhTour.DuongDan6,
                                   DuongDan7 = anhTour.DuongDan7,
                                   soluongcon = 0
                               }).FirstOrDefault();
            tourDetails.soluongcon = Helper.Helper.CaculateCustomer(tourEntity, idTour);
            return View("DetailTour", tourDetails);
        }

        //Pagination
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


            return View("Index", dataToDisplay);
        }

        public ActionResult FilterHard(DateTime? ngaydi, int? quantityDate, int? quantitiCus, int page = 1, int pageSize = 9)
        {
            var tours = new List<Tour>();
            tours = SearchTourHelper.HardSearch(tourEntity, ngaydi, quantityDate, quantitiCus);
            var tourSearch = SearchTourHelper.HardSearch(tourEntity, ngaydi, quantityDate, quantitiCus);
            var totalRecords = tourSearch.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Đảm bảo rằng trang hiện tại không vượt quá số trang mới tính được
            if (page > totalPages)
            {
                page = totalPages;
            }

            var dataToDisplay = tourSearch
                .OrderBy(t => t.id_tour)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = (page > 1);
            ViewBag.HasNextPage = (page < totalPages);


            //return TourDuLich();
            return View("Index", dataToDisplay);
        }



        //Set UP show Location to Search incategory 
        public ActionResult Category()
        {
            var model = tourEntity.DiaDiem.ToList();
            return PartialView("_category_DD", model);
        }
    }
}