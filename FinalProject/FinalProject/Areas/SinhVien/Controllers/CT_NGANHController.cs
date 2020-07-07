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
    public class CT_NGANHController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        // GET: CT_NGANH
        public ActionResult Index(string id = "0001")
        {
            ViewData["TenDangNhap"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string id_nganh = db.SINHVIENs.Find(id).MaNganh.ToString();
            var cT_NGANH = db.CT_NGANH.Include(c => c.MONHOC).Include(c => c.NGANH).Where(c => c.MaNganh == id_nganh).OrderBy(c => c.HocKy);
            return View(cT_NGANH.ToList());
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
