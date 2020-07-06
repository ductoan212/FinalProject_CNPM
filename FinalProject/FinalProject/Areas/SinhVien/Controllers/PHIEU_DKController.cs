using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.SinhVien.Controllers
{
    public class PHIEU_DKController : Controller
    {
        private CNPMEntities db = new CNPMEntities();
        private string TenDangNhap;

        public ActionResult IndexSV(string id = "0001")
        {
            TenDangNhap = id;
            ViewData["TenDangNhap"] = id;
            var pHIEU_DK = db.PHIEU_DK.Include(p => p.HKNH).Include(p => p.SINHVIEN).Where(p => p.MaSinhVien == id);
            return View(pHIEU_DK.ToList());
        }

        // GET: PHIEU_DK/Details/5
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
            ViewData["TenDangNhap"] = pHIEU_DK.MaSinhVien;
            ViewBag.CT_DK = db.CT_PHIEUDK.Where(m => m.SoPhieuDK == id).ToList();
            return View(pHIEU_DK);
        }

        // GET: PHIEU_DK/Create
        public ActionResult Create(string id_sv = "0001", int id = 0)
        {
            ViewBag.m = "Dung";
            if (id == 1)
                ViewBag.m = "Sai";
            TenDangNhap = id_sv;
            ViewData["TenDangNhap"] = id_sv;
            ViewBag.MaSinhVien = db.SINHVIENs.Find(id_sv); //Tìm sv có id = id_sv
            //ViewBag.MaSinhVien = new SelectList(db.SINHVIENs, "MaSinhVien", "HoTen"); //Lấy hết sv, này test thôi

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
            model.MaSinhVien = ViewBag.MaSinhVien.MaSinhVien; //Gán mặc định sv khi lập bc dựa vào id_sv đầu vào
            model.NgayDK = DateTime.Now; //Gán ngày đk
            ViewBag.NgayDK = model.NgayDK;
            return View(model);
        }

        // POST: PHIEU_DK/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhieuDK,MaSinhVien,NgayDK,MaHKNH,SoTienDangKy,SoTienPhaiDong,SoTienDaDong,SoTienConLai")] PHIEU_DK pHIEU_DK)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.PHIEU_DK.Add(pHIEU_DK);
                    db.SaveChanges();
                    return RedirectToAction("Create", "CT_PHIEUDK", new { @id = pHIEU_DK.SoPhieuDK, @hknh = pHIEU_DK.MaHKNH, @id_sv = pHIEU_DK.MaSinhVien });
                }

                ViewBag.MaHKNH = new SelectList(db.HKNHs, "MaHKNH", "HocKy", pHIEU_DK.MaHKNH);
                ViewBag.MaSinhVien = new SelectList(db.SINHVIENs, "MaSinhVien", "HoTen", pHIEU_DK.MaSinhVien);
                return View(pHIEU_DK);
            }
            catch(Exception e)
            {
                return RedirectToAction("Create", "PHIEU_DK", new { id_sv = pHIEU_DK.MaSinhVien, id = 1 });
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
