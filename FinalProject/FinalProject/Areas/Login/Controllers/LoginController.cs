using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.Login.Controllers
{
    public class LoginController : Controller
    {
        private CNPMEntities db = new CNPMEntities();
        // GET: Login/Login
        public ActionResult Login(int id = 0)
        {
            ViewBag.m = "Dung";
            if (id == 1)
                ViewBag.m = "Sai";
            return View();
        }
        public ActionResult ErrorPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string TenDangNhap, string MatKhau)
        {
            var nGUOIDUNG = db.NGUOIDUNGs.Where(nd => nd.TenDangNhap == TenDangNhap & nd.MatKhau == MatKhau);
            if (nGUOIDUNG.ToList().Count() == 0)
            {
                return RedirectToAction("Login", "Login", new { id = 1 });
            }
            else
            {
                var ListAdmin = from nd in db.NGUOIDUNGs
                                join nnd in db.NHOMNGUOIDUNGs on nd.IDNhomNguoiDung equals nnd.IDNhomNguoiDung
                                where nnd.TenNhomNguoiDung.Equals("Admin")
                                select nd.TenDangNhap;
                var ListPDT = from nd in db.NGUOIDUNGs
                              join nnd in db.NHOMNGUOIDUNGs on nd.IDNhomNguoiDung equals nnd.IDNhomNguoiDung
                              where nnd.TenNhomNguoiDung.Equals("Phòng đào tạo")
                              select nd.TenDangNhap;
                if (ListAdmin.Contains(TenDangNhap))
                {
                    return RedirectToAction("HomeAdmin", "Admin", new { area = "Admin" });
                }
                else if (ListPDT.Contains(TenDangNhap))
                {
                    return RedirectToAction("HomePDT", "PDT", new { area = "PDT" });
                }
                return RedirectToAction("HomeSinhVien", "SinhVien", new { area = "SinhVien", TenDangNhap = TenDangNhap });
            }
        }

    }
}