using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.SinhVien.Controllers
{
    public class SinhVienController : Controller
    {
        private CNPMEntities db = new CNPMEntities();
        // GET: SinhVien/SinhVien
        public ActionResult HomeSinhVien(string TenDangNhap)
        {
            SINHVIEN sINHVIEN = db.SINHVIENs.FirstOrDefault(s => s.MaSinhVien == TenDangNhap);
            ViewData["TenDangNhap"] = sINHVIEN.MaSinhVien;
            return View();
        }
    }
}