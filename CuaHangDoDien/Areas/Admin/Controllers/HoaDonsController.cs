using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CuaHangDoDien.Models.DBConection;

namespace CuaHangDoDien.Areas.Admin.Controllers
{
    public class HoaDonsController : LoginManagerController
    {
        private CuaHangDienMayEntities db = new CuaHangDienMayEntities();

        // GET: Admin/HoaDons
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.SanPham).Include(h => h.User).Include(h => h.User1);
            return View(hoaDons.ToList());
        }

        // GET: Admin/HoaDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Create
        public ActionResult Create()
        {
            ViewBag.ID_SP = new SelectList(db.SanPhams, "ID_SP", "TenSP");
            ViewBag.ID_KH = new SelectList(db.Users, "ID_User", "Ten");
            ViewBag.ID_NV = new SelectList(db.Users, "ID_User", "Ten");
            return View();
        }

        // POST: Admin/HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HoaDon,ID_KH,ID_NV,ID_SP,SoLuong,NgayBan,Status")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SP = new SelectList(db.SanPhams, "ID_SP", "TenSP", hoaDon.ID_SP);
            ViewBag.ID_KH = new SelectList(db.Users, "ID_User", "Ten", hoaDon.ID_KH);
            ViewBag.ID_NV = new SelectList(db.Users, "ID_User", "Ten", hoaDon.ID_NV);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SP = new SelectList(db.SanPhams, "ID_SP", "TenSP", hoaDon.ID_SP);
            ViewBag.ID_KH = new SelectList(db.Users, "ID_User", "Ten", hoaDon.ID_KH);
            ViewBag.ID_NV = new SelectList(db.Users, "ID_User", "Ten", hoaDon.ID_NV);
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HoaDon,ID_KH,ID_NV,ID_SP,SoLuong,NgayBan,Status")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SP = new SelectList(db.SanPhams, "ID_SP", "TenSP", hoaDon.ID_SP);
            ViewBag.ID_KH = new SelectList(db.Users, "ID_User", "Ten", hoaDon.ID_KH);
            ViewBag.ID_NV = new SelectList(db.Users, "ID_User", "Ten", hoaDon.ID_NV);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
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
