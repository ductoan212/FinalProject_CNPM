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
    public class PHIEU_DKController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        // GET: PDT/PHIEU_DK
        public ActionResult Index()
        {
            var pHIEU_DK = db.PHIEU_DK.Include(p => p.HKNH).Include(p => p.SINHVIEN);
            return View(pHIEU_DK.ToList());
        }

        // GET: PDT/PHIEU_DK/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEU_DK pHIEU_DK = db.PHIEU_DK.Find(id);
            if (pHIEU_DK == null)
            {
                return HttpNotFound();
            }

            ViewBag.CT_DK = db.CT_PHIEUDK.Where(m => m.SoPhieuDK == id).ToList();
            return View(pHIEU_DK);
        }

        // GET: PDT/PHIEU_DK/Create
        public ActionResult Create()
        {
            ViewBag.MaSinhVien = new SelectList(db.SINHVIENs, "MaSinhVien", "MaSinhVien"); //Lấy hết sv

            ViewBag.hknh = db.HKNHs; //Lấy hết học kỳ năm học

            //Tạo id phiếu đk tăng dần
            int id_num = 1000;
            if (db.PHIEU_DK.Count() != 0)
            {
                var phieu_last = db.PHIEU_DK.OrderByDescending(p => p.SoPhieuDK).FirstOrDefault();
                id_num = Int32.Parse(phieu_last.SoPhieuDK) + 1;
            }
            ViewBag.id_phieu = id_num.ToString();

            PHIEU_DK model = new PHIEU_DK(); //Tạo mới phiếu đk
            model.SoPhieuDK = ViewBag.id_phieu; //Tạo id tự tăng cho phiếu đk
            model.NgayDK = DateTime.Now; //Gán ngày đk
            ViewBag.NgayDK = model.NgayDK;
            return View(model);
        }

        // POST: PDT/PHIEU_DK/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhieuDK,MaSinhVien,NgayDK,MaHKNH,SoTienDangKy,SoTienPhaiDong,SoTienDaDong,SoTienConLai")] PHIEU_DK pHIEU_DK)
        {
            if (ModelState.IsValid)
            {
                db.PHIEU_DK.Add(pHIEU_DK);
                db.SaveChanges();
                return RedirectToAction("Create", "CT_PHIEUDK", new { @id = pHIEU_DK.SoPhieuDK, @hknh = pHIEU_DK.MaHKNH });
            }

            ViewBag.MaHKNH = new SelectList(db.HKNHs, "MaHKNH", "HocKy", pHIEU_DK.MaHKNH);
            ViewBag.MaSinhVien = new SelectList(db.SINHVIENs, "MaSinhVien", "HoTen", pHIEU_DK.MaSinhVien);
            return View(pHIEU_DK);
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
