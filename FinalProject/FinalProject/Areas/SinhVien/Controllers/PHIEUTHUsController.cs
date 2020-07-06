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
    public class PHIEUTHUsController : Controller
    {
        private CNPMEntities db = new CNPMEntities();
        private string _id;

        // GET: SinhVien/PHIEUTHUs
        public ActionResult Index(string id)
        {
            _id = id;
            ViewBag.ListPhieuThu = db.PHIEUTHUs.Where(m => m.PHIEU_DK.MaSinhVien == id);
            ViewData["TenDangNhap"] = id;
            return View();
        }

        // GET: SinhVien/PHIEUTHUs/Details/5
        public ActionResult Details(string id, string id_sv)
        {
            ViewData["TenDangNhap"] = id_sv;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHU pHIEUTHU = db.PHIEUTHUs.Find(id);
            if (pHIEUTHU == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUTHU);
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    }
}
