using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.PDT.Controllers
{
    public class SINHVIENsController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        public SINHVIEN GetSINHVIEN(string id)
        {
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            return sINHVIEN;
        }

        // GET: PDT/SINHVIENs
        public ActionResult Index()
        {
            var sINHVIENs = db.SINHVIENs.Include(s => s.DOITUONG).Include(s => s.HUYEN).Include(s => s.NGANH);
            return View(sINHVIENs.ToList());
        }

        // GET: PDT/SINHVIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }

        public JsonResult getHuyen(string id)
        {
            var ddlHuyen = db.HUYENs.Where(x => x.MaTinh == id).ToList();
            List<SelectListItem> listHuyen = new List<SelectListItem>();

            listHuyen.Add(new SelectListItem { Text = "-- Chọn Huyện --", Value = "0" });
            if (ddlHuyen != null)
            {
                foreach (var x in ddlHuyen)
                {
                    listHuyen.Add(new SelectListItem { Text = x.TenHuyen, Value = x.MaHuyen.ToString() });
                }
            }
            return Json(new SelectList(listHuyen, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

        // GET: SINHVIENs/Create
        public ActionResult Create(int id = 0)
        {
            ViewBag.m = "Dung";
            if (id == 1)
                ViewBag.m = "Sai";
            //bindTinh();
            ViewBag.MaDoiTuong = new SelectList(db.DOITUONGs, "MaDoiTuong", "TenDoiTuong");
            ViewBag.MaTinh = new SelectList(db.TINHs, "MaTinh", "TenTinh");
            ViewBag.MaHuyen = new SelectList(db.HUYENs, "MaHuyen", "TenHuyen");
            ViewBag.MaNganh = new SelectList(db.NGANHs, "MaNganh", "TenNganh");
            return View();
        }


        // POST: SINHVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSinhVien,HoTen,GioiTinh,NgaySinh,MaHuyen,MaDoiTuong,MaNganh")] SINHVIEN sINHVIEN)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SINHVIENs.Add(sINHVIEN);
                    db.SaveChanges();
                    ViewBag.Message = "Your application description page.";
                    return RedirectToAction("Index");
                }

                ViewBag.MaDoiTuong = new SelectList(db.DOITUONGs, "MaDoiTuong", "TenDoiTuong", sINHVIEN.MaDoiTuong);
                ViewBag.MaTinh = new SelectList(db.TINHs, "MaTinh", "TenTinh", sINHVIEN.TINH.MaTinh);
                ViewBag.MaHuyen = new SelectList(db.HUYENs, "MaHuyen", "TenHuyen", sINHVIEN.MaHuyen);
                ViewBag.MaNganh = new SelectList(db.NGANHs, "MaNganh", "TenNganh", sINHVIEN.MaNganh);
                return View(sINHVIEN);
            }
            catch (Exception e)
            {
                return RedirectToAction("Create", "SINHVIENs", new { id = 1 });
                throw e;
            }
        }

        // GET: SINHVIENs/Edit/5
        public ActionResult Edit(string id, int ed = 0)
        {
            ViewBag.m = "Dung";
            if (ed == 1)
                ViewBag.m = "Sai";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDoiTuong = new SelectList(db.DOITUONGs, "MaDoiTuong", "TenDoiTuong", sINHVIEN.MaDoiTuong);
            ViewBag.MaHuyen = new SelectList(db.HUYENs, "MaHuyen", "TenHuyen", sINHVIEN.MaHuyen);
            ViewBag.MaTinh = new SelectList(db.TINHs, "MaTinh", "TenTinh", sINHVIEN.MaTinh);
            ViewBag.MaNganh = new SelectList(db.NGANHs, "MaNganh", "TenNganh", sINHVIEN.MaNganh);
            return View(sINHVIEN);
        }

        // POST: SINHVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSinhVien,HoTen,GioiTinh,NgaySinh,MaHuyen,MaDoiTuong,MaNganh")] SINHVIEN sINHVIEN)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(sINHVIEN).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                ViewBag.MaDoiTuong = new SelectList(db.DOITUONGs, "MaDoiTuong", "TenDoiTuong", sINHVIEN.MaDoiTuong);
                ViewBag.MaHuyen = new SelectList(db.HUYENs, "MaHuyen", "TenHuyen", sINHVIEN.MaHuyen);
                ViewBag.MaTinh = new SelectList(db.TINHs, "MaTinh", "TenTinh", sINHVIEN.MaTinh);
                ViewBag.MaNganh = new SelectList(db.NGANHs, "MaNganh", "TenNganh", sINHVIEN.MaNganh);
                return View(sINHVIEN);
            }
            catch(Exception e)
            {
                return RedirectToAction("Edit", "SINHVIENs", new { id = sINHVIEN.MaSinhVien, ed = 1 });
                throw e;
            }
        }

        // GET: PDT/SINHVIENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }

        // POST: PDT/SINHVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
                db.SINHVIENs.Remove(sINHVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Delete", "SINHVIENs", new { id = id});
            }
            
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
