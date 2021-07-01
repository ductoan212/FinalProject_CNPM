using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.Admin.Controllers
{
    public class NGUOIDUNGsController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        // GET: Admin/NGUOIDUNGs
        public ActionResult Index()
        {
            var nGUOIDUNGs = db.NGUOIDUNGs.Include(n => n.NHOMNGUOIDUNG);
            return View(nGUOIDUNGs.ToList());
        }

        // GET: Admin/NGUOIDUNGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNG);
        }

        // GET: Admin/NGUOIDUNGs/Create
        public ActionResult Create(int id = 0)
        {
            ViewBag.m = "Dung";
            if (id == 1)
                ViewBag.m = "Sai";
            ViewBag.IDNhomNguoiDung = new SelectList(db.NHOMNGUOIDUNGs, "IDNhomNguoiDung", "TenNhomNguoiDung");
            return View();
        }

        // POST: Admin/NGUOIDUNGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenDangNhap,MatKhau,IDNhomNguoiDung")] NGUOIDUNG nGUOIDUNG)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.NGUOIDUNGs.Add(nGUOIDUNG);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.IDNhomNguoiDung = new SelectList(db.NHOMNGUOIDUNGs, "IDNhomNguoiDung", "TenNhomNguoiDung", nGUOIDUNG.IDNhomNguoiDung);
                return View(nGUOIDUNG);
            }
            catch(Exception e)
            {
                return RedirectToAction("Create", "NGUOIDUNGs", new { id = 1 });
            }
        }

        // GET: Admin/NGUOIDUNGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNhomNguoiDung = new SelectList(db.NHOMNGUOIDUNGs, "IDNhomNguoiDung", "TenNhomNguoiDung", nGUOIDUNG.IDNhomNguoiDung);
            return View(nGUOIDUNG);
        }

        // POST: Admin/NGUOIDUNGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenDangNhap,MatKhau,IDNhomNguoiDung")] NGUOIDUNG nGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUOIDUNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDNhomNguoiDung = new SelectList(db.NHOMNGUOIDUNGs, "IDNhomNguoiDung", "TenNhomNguoiDung", nGUOIDUNG.IDNhomNguoiDung);
            return View(nGUOIDUNG);
        }

        // GET: Admin/NGUOIDUNGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNG);
        }

        // POST: Admin/NGUOIDUNGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
                db.NGUOIDUNGs.Remove(nGUOIDUNG);
                db.SaveChanges();
            }
            catch { }
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
