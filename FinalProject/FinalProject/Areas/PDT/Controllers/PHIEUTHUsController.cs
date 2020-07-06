using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.PDT.Controllers
{
    public class PHIEUTHUsController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        // GET: PDT/PHIEUTHUs
        public ActionResult Index()
        {
            var pHIEUTHUs = db.PHIEUTHUs.Include(p => p.PHIEU_DK);
            return View(pHIEUTHUs.ToList());
        }

        // GET: PDT/PHIEUTHUs/Details/5
        public ActionResult Details(string id)
        {
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

        // GET: PDT/PHIEUTHUs/Create
        public ActionResult Create(int id = 0, string id_pt = "")
        {
            ViewBag.m = "dung";
            if (id == 1)
                ViewBag.m = "Sai";
            ViewBag.SoPhieuDK = new SelectList(db.PHIEU_DK, "SoPhieuDK", "SoPhieuDK");
            ViewBag.conlai = "";
            if(id_pt != "")
                ViewBag.conlai = db.PHIEU_DK.Find(id_pt).SoTienConLai.ToString();
            //Tạo id phiếu thu tăng dần
            int id_num = 1000;
            if (db.PHIEUTHUs.Count() != 0)
            {
                var phieu_last = db.PHIEUTHUs.OrderByDescending(p => p.SoPhieuThu).FirstOrDefault();
                id_num = Int32.Parse(phieu_last.SoPhieuThu) + 1;
            }
            ViewBag.id_phieu = id_num.ToString();

            PHIEUTHU model = new PHIEUTHU(); //Tạo mới phiếu đk
            model.SoPhieuThu = ViewBag.id_phieu; //Tạo id tự tăng cho phiếu đk
            model.NgayLap = DateTime.Now; //Gán ngày đk
            model.SoTienThu = 0;
            ViewBag.NgayLap = model.NgayLap;
            return View(model);
        }

        // POST: PDT/PHIEUTHUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhieuThu,SoPhieuDK,NgayLap,SoTienThu")] PHIEUTHU pHIEUTHU)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.PHIEUTHUs.Add(pHIEUTHU);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.SoPhieuDK = new SelectList(db.PHIEU_DK, "SoPhieuDK", "SoPhieuDK", pHIEUTHU.SoPhieuDK);
                return View(pHIEUTHU);
            }
            catch (Exception e)
            {
                string id_pt = pHIEUTHU.SoPhieuDK;
                string con_lai = db.PHIEU_DK.Find(id_pt).SoTienConLai.ToString();
                int cl;
                Int32.TryParse(con_lai, out cl);

                return RedirectToAction("Create", "PHIEUTHUs", new { id = 1, id_pt = id_pt });
            }

        }

        // GET: PDT/PHIEUTHUs/Edit/5
        public ActionResult Edit(string id, int ed = 0)
        {
            ViewBag.m = "dung";
            if (ed == 1)
            {
                ViewBag.m = "sai";
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHU pHIEUTHU = db.PHIEUTHUs.Find(id);
            if (pHIEUTHU == null)
            {
                return HttpNotFound();
            }
            ViewBag.SoPhieuDK = new SelectList(db.PHIEU_DK, "SoPhieuDK", "SoPhieuDK", pHIEUTHU.SoPhieuDK);
            return View(pHIEUTHU);
        }

        // POST: PDT/PHIEUTHUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPhieuThu,SoPhieuDK,NgayLap,SoTienThu")] PHIEUTHU pHIEUTHU)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(pHIEUTHU).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.SoPhieuDK = new SelectList(db.PHIEU_DK, "SoPhieuDK", "SoPhieuDK", pHIEUTHU.SoPhieuDK);
                return View(pHIEUTHU);
            }
            catch (Exception e)
            {
                return RedirectToAction("Edit", "PHIEUTHUs", new { id = pHIEUTHU.SoPhieuThu, ed = 1});
            }
        }

        // GET: PDT/PHIEUTHUs/Delete/5
        public ActionResult Delete(string id)
        {
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

        // POST: PDT/PHIEUTHUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUTHU pHIEUTHU = db.PHIEUTHUs.Find(id);
            db.PHIEUTHUs.Remove(pHIEUTHU);
            db.SaveChanges();
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
