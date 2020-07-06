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
    public class CT_NGANHController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        // GET: PDT/CT_NGANH
        public ActionResult Index(string id)
        {
            var cT_NGANH = db.CT_NGANH.Include(c => c.MONHOC).Include(c => c.NGANH).Where(n => n.MaNganh == id).OrderBy(n => n.HocKy).ToList();
            ViewData["TenNganh"] = id;
            if (cT_NGANH == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(cT_NGANH);
        }

        // GET: PDT/CT_NGANH/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_NGANH cT_NGANH = db.CT_NGANH.Find(id);
            if (cT_NGANH == null)
            {
                return HttpNotFound();
            }
            return View(cT_NGANH);
        }

        // GET: PDT/CT_NGANH/Create
        public ActionResult Create()
        {
            ViewBag.MaMonHoc = new SelectList(db.MONHOCs, "MaMonHoc", "TenMonHoc");
            ViewBag.MaNganh = new SelectList(db.NGANHs, "MaNganh", "TenNganh");
            return View();
        }

        // POST: PDT/CT_NGANH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNganh,MaMonHoc,HocKy")] CT_NGANH cT_NGANH)
        {
            if (ModelState.IsValid)
            {
                db.CT_NGANH.Add(cT_NGANH);
                db.SaveChanges();
                return RedirectToAction("Index", "NGANHs");
            }

            ViewBag.MaMonHoc = new SelectList(db.MONHOCs, "MaMonHoc", "TenMonHoc", cT_NGANH.MaMonHoc);
            ViewBag.MaNganh = new SelectList(db.NGANHs, "MaNganh", "TenNganh", cT_NGANH.NGANH.TenNganh);
            return View(cT_NGANH);
        }

        // GET: PDT/CT_NGANH/Edit/5
        public ActionResult Edit(string MaNganh, string MaMonHoc)
        {
            if (MaNganh == null || MaMonHoc == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_NGANH cT_NGANH = db.CT_NGANH.Find(MaNganh, MaMonHoc);
            if (cT_NGANH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMonHoc = new SelectList(db.MONHOCs, "MaMonHoc", "TenMonHoc", cT_NGANH.MaMonHoc);
            ViewBag.MaNganh = new SelectList(db.NGANHs, "TenNganh", "MaKhoa", cT_NGANH.NGANH.TenNganh);
            return View(cT_NGANH);
        }

        // POST: PDT/CT_NGANH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNganh,MaMonHoc,HocKy")] CT_NGANH cT_NGANH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_NGANH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "NGANHs");
            }
            ViewBag.MaMonHoc = new SelectList(db.MONHOCs, "MaMonHoc", "TenMonHoc", cT_NGANH.MaMonHoc);
            ViewBag.MaNganh = new SelectList(db.NGANHs, "MaNganh", "MaKhoa", cT_NGANH.MaNganh);
            //return RedirectToAction("Index", new { id = cT_NGANH.MaNganh });
            return RedirectToAction("Index", "NGANHs");
        }

        // GET: PDT/CT_NGANH/Delete/5
        public ActionResult Delete(string MaNganh, string MaMonHoc)
        {
            if (MaNganh == null || MaMonHoc == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_NGANH cT_NGANH = db.CT_NGANH.Find(MaNganh, MaMonHoc);
            if (cT_NGANH == null)
            {
                return HttpNotFound();
            }
            return View(cT_NGANH);
        }

        // POST: PDT/CT_NGANH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string MaNganh, string MaMonHoc)
        {
            CT_NGANH cT_NGANH = db.CT_NGANH.Find(MaNganh, MaMonHoc);
            db.CT_NGANH.Remove(cT_NGANH);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return RedirectToAction("Index", "NGANHs");

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
