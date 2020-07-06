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
    public class CT_PHIEUDKController : Controller
    {
        private CNPMEntities db = new CNPMEntities();
        private static string _SoPhieuDK;
        private static string _MaHKNH;

        // GET: CT_PHIEUDK
        public ActionResult Index()
        {
            var cT_PHIEUDK = db.CT_PHIEUDK.Include(c => c.DS_MONHOC_MO).Include(c => c.PHIEU_DK);
            return View(cT_PHIEUDK.ToList());
        }

        // GET: CT_PHIEUDK/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEUDK cT_PHIEUDK = db.CT_PHIEUDK.Find(id);
            if (cT_PHIEUDK == null)
            {
                return HttpNotFound();
            }
            return View(cT_PHIEUDK);
        }

        // GET: CT_PHIEUDK/Create
        public ActionResult Create(string id = null, string hknh = null, string id_sv = null)
        {
            ViewData["TenDangNhap"] = id_sv;
            CT_PHIEUDK model = new CT_PHIEUDK();
            ViewBag.MaMo = db.DS_MONHOC_MO.Where(c => c.MaHKNH == hknh).ToList();
            //ViewBag.SoPhieuDK = new SelectList(db.PHIEU_DK, "SoPhieuDK", "SoPhieuDK");

            var ds_da_dk = db.CT_PHIEUDK.Where(m => m.SoPhieuDK == id);

            List<DS_MONHOC_MO> ds_mh_mo = db.DS_MONHOC_MO.Where(c => c.MaHKNH == hknh).ToList();
            List<CT_PHIEUDK> ds_ct_pdk = new List<CT_PHIEUDK>();
            foreach (DS_MONHOC_MO item in ds_mh_mo)
            {
                CT_PHIEUDK ct = new CT_PHIEUDK();
                ct.SoPhieuDK = id;
                ct.MaMo = item.MaMo;
                ct.GhiChu = null;
                ct.DS_MONHOC_MO = db.DS_MONHOC_MO.Where(m => m.MaMo == ct.MaMo).FirstOrDefault();

                if (ds_da_dk.Where(m => m.MaMo == item.MaMo).Count() == 0)
                    ds_ct_pdk.Add(ct);
            }

            _SoPhieuDK = id;
            _MaHKNH = hknh;
            ViewBag.SoPhieuDK = id;
            ViewBag.ListCT = ds_ct_pdk.ToList();

            return View();
        }

        // POST: CT_PHIEUDK/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection formCollection)
        {
            string[] ids = formCollection["ID"]?.Split(new char[] { ',' });
            if (ids == null)
                return RedirectToAction("Details", "PHIEU_DK", new { @id = _SoPhieuDK });
            foreach (string id in ids)
            {
                //var ct_pdk = ds_ct_pdk.Find(m => m.MaMo == id);
                CT_PHIEUDK ct_pdk = new CT_PHIEUDK();
                ct_pdk.SoPhieuDK = _SoPhieuDK;
                ct_pdk.MaMo = id;
                ct_pdk.GhiChu = null;
                if (ct_pdk != null)
                {
                    this.db.CT_PHIEUDK.Add(ct_pdk);
                    this.db.SaveChanges();
                }
            }
            return RedirectToAction("Details", "PHIEU_DK", new { @id = _SoPhieuDK });
        }

        // GET: CT_PHIEUDK/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEUDK cT_PHIEUDK = db.CT_PHIEUDK.Find(id);
            if (cT_PHIEUDK == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMo = new SelectList(db.DS_MONHOC_MO, "MaMo", "MaHKNH", cT_PHIEUDK.MaMo);
            ViewBag.SoPhieuDK = new SelectList(db.PHIEU_DK, "SoPhieuDK", "MaSinhVien", cT_PHIEUDK.SoPhieuDK);
            return View(cT_PHIEUDK);
        }

        // POST: CT_PHIEUDK/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPhieuDK,MaMo,GhiChu")] CT_PHIEUDK cT_PHIEUDK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_PHIEUDK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMo = new SelectList(db.DS_MONHOC_MO, "MaMo", "MaHKNH", cT_PHIEUDK.MaMo);
            ViewBag.SoPhieuDK = new SelectList(db.PHIEU_DK, "SoPhieuDK", "MaSinhVien", cT_PHIEUDK.SoPhieuDK);
            return View(cT_PHIEUDK);
        }

        // GET: CT_PHIEUDK/Delete/5
        public ActionResult Delete(string id_pdk, string id_mo, int dd = 0)
        {
            ViewBag.m = "Dung";
            if (dd == 1)
                ViewBag.m = "Sai";
            if (id_pdk == null || id_mo == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEUDK cT_PHIEUDK = db.CT_PHIEUDK.Where(m => m.SoPhieuDK == id_pdk).Where(m => m.MaMo == id_mo).FirstOrDefault();
            if (cT_PHIEUDK == null)
            {
                return HttpNotFound();
            }
            return View(cT_PHIEUDK);
        }

        // POST: CT_PHIEUDK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id_pdk, string id_mo)
        {
            try
            {
                CT_PHIEUDK cT_PHIEUDK = db.CT_PHIEUDK.Where(m => m.SoPhieuDK == id_pdk).Where(m => m.MaMo == id_mo).FirstOrDefault();
                db.CT_PHIEUDK.Remove(cT_PHIEUDK);
                db.SaveChanges();
                return RedirectToAction("Details", "PHIEU_DK", new { @id = id_pdk });
            }
            catch(Exception e)
            {
                return RedirectToAction("Delete", "CT_PHIEUDK", new { id_pdk = id_pdk, id_mo = id_mo, dd = 1 });
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
