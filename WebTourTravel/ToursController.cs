using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebTourTravel
{
    public class ToursController : Controller
    {
        private TourDuLichEntities db = new TourDuLichEntities();

        // GET: Tours
        public ActionResult Index()
        {
            var tour = db.Tour.Include(t => t.HuongDanVien).Include(t => t.TourMau);
            return View(tour.ToList());
        }

        // GET: Tours/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: Tours/Create
        public ActionResult Create()
        {
            ViewBag.id_hdv = new SelectList(db.HuongDanVien, "id_hdv", "HoTen");
            ViewBag.id_tourmau = new SelectList(db.TourMau, "id_tourmau", "TenTourMau");
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tour,id_tourmau,id_hdv,TenTour,KhoiHanh,TapTrung,ThoiGian,NoiKhoiHanh,SoLuongToiDa,GiaNguoiLon,GiaTreEm,DanhGia,Avata")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Tour.Add(tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_hdv = new SelectList(db.HuongDanVien, "id_hdv", "HoTen", tour.id_hdv);
            ViewBag.id_tourmau = new SelectList(db.TourMau, "id_tourmau", "TenTourMau", tour.id_tourmau);
            return View(tour);
        }

        // GET: Tours/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_hdv = new SelectList(db.HuongDanVien, "id_hdv", "HoTen", tour.id_hdv);
            ViewBag.id_tourmau = new SelectList(db.TourMau, "id_tourmau", "TenTourMau", tour.id_tourmau);
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tour,id_tourmau,id_hdv,TenTour,KhoiHanh,TapTrung,ThoiGian,NoiKhoiHanh,SoLuongToiDa,GiaNguoiLon,GiaTreEm,DanhGia,Avata")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_hdv = new SelectList(db.HuongDanVien, "id_hdv", "HoTen", tour.id_hdv);
            ViewBag.id_tourmau = new SelectList(db.TourMau, "id_tourmau", "TenTourMau", tour.id_tourmau);
            return View(tour);
        }

        // GET: Tours/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tour tour = db.Tour.Find(id);
            db.Tour.Remove(tour);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
