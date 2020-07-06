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
    public class BAOCAO_SV_NOHPController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        //GET: BAOCAO_SV_NOHP
        //public ActionResult Index(string id)
        //{
        //    var bAOCAO_SV_NOHP = db.BAOCAO_SV_NOHP.Include(b => b.SINHVIEN);

        //    List<BAOCAO_SV_NOHP> bao_cao = db.BAOCAO_SV_NOHP.ToList();
        //    List<SINHVIEN> sinh_vien = db.SINHVIENs.ToList();
        //    List<HKNH> hk_nh = db.HKNHs.ToList();

        //    var Record = from b in bao_cao
        //                 join s in sinh_vien on b.MaSinhVien equals s.MaSinhVien into table1
        //                 from s in table1.ToList()
        //                 join h in hk_nh on b.MaHKNH equals h.MaHKNH into table2
        //                 from h in table2.ToList()
        //                 select new BAOCAO_SV_NOHP
        //                 {
        //                     HKNH = h,
        //                     SINHVIEN = s,
        //                     SoTienConLai = b.SoTienConLai
        //                 };
        //    if (id==null)
        //    {
        //        ViewBag.Test = bAOCAO_SV_NOHP.ToList();
        //        return View(Record.ToList());
        //    }
        //    var baocao = from b in bao_cao
        //                 join s in sinh_vien on b.MaSinhVien equals s.MaSinhVien into table1
        //                 where b.MaHKNH == id /*Co them dieu kien*/
        //                 from s in table1.ToList()
        //                 join h in hk_nh on b.MaHKNH equals h.MaHKNH into table2
        //                 from h in table2.ToList()
        //                 select new BAOCAO_SV_NOHP
        //                 {
        //                     HKNH = h,
        //                     SINHVIEN = s,
        //                     SoTienConLai = b.SoTienConLai
        //                 };

        //    ViewBag.Message = id;
        //    if (baocao.Count() == 0)
        //        return RedirectToAction("ListHK", new { m = 1 });
        //    return View(baocao.ToList());
        //}


        //GET: BAOCAO_SV_NOHP
        public ActionResult Index(string id)
        {
            var bAOCAO_SV_NOHP = db.BAOCAO_SV_NOHP.Include(b => b.SINHVIEN);

            List<BAOCAO_SV_NOHP> bao_cao = db.BAOCAO_SV_NOHP.ToList();
            List<SINHVIEN> sinh_vien = db.SINHVIENs.ToList();
            List<HKNH> hk_nh = db.HKNHs.ToList();
            List<PHIEU_DK> phieu_dk = db.PHIEU_DK.ToList();

            var Record = from b in bao_cao
                         join s in sinh_vien on b.MaSinhVien equals s.MaSinhVien into table1
                         from s in table1.ToList()
                         join h in hk_nh on b.MaHKNH equals h.MaHKNH into table2
                         from h in table2.ToList()
                         select new BAOCAO_SV_NOHP
                         {
                             HKNH = h,
                             SINHVIEN = s,
                             SoTienConLai = b.SoTienConLai
                         };
            if (id == null)
            {
                ViewBag.Test = bAOCAO_SV_NOHP.ToList();
                return View(Record.ToList());
            }
            var baocao = from p in phieu_dk
                         join h in hk_nh on p.MaHKNH equals h.MaHKNH into table1
                         where p.MaHKNH == id
                         from h in table1.ToList()
                         select new BAOCAO_SV_NOHP
                         {
                             PHIEU_DK = p,
                             HKNH = h
                         };

            ViewBag.Message = id;
            //var bc = baocao.Where(m => m.SoTienConLai.ToString() != "0.00");
            //var bc = baocao.Where(m => m.SoTienConLai > 0);
            if (baocao.Count() == 0)
                return RedirectToAction("ListHK", new { m = 1 });
            
            return View(baocao.ToList());
        }

        public ActionResult ListHK(int m = 0)
        {
            ViewBag.message = "";
            if (m == 1)
                ViewBag.message = "Học kỳ này không có sinh viên nợ học phí";
            var namHoc = db.HKNHs;
            return View(db.HKNHs.ToList());
        }

        // GET: BAOCAO_SV_NOHP/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAO_SV_NOHP bAOCAO_SV_NOHP = db.BAOCAO_SV_NOHP.Find(id);
            if (bAOCAO_SV_NOHP == null)
            {
                return HttpNotFound();
            }
            return View(bAOCAO_SV_NOHP);
        }

        // GET: BAOCAO_SV_NOHP/Create
        public ActionResult Create()
        {
            ViewBag.MaSinhVien = new SelectList(db.HKNHs, "MaHKNH", "HocKy");
            ViewBag.MaSinhVien = new SelectList(db.SINHVIENs, "MaSinhVien", "HoTen");
            return View();
        }

        // POST: BAOCAO_SV_NOHP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHKNH,MaSinhVien,SoTienConLai")] BAOCAO_SV_NOHP bAOCAO_SV_NOHP)
        {
            if (ModelState.IsValid)
            {
                db.BAOCAO_SV_NOHP.Add(bAOCAO_SV_NOHP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSinhVien = new SelectList(db.HKNHs, "MaHKNH", "HocKy", bAOCAO_SV_NOHP.MaSinhVien);
            ViewBag.MaSinhVien = new SelectList(db.SINHVIENs, "MaSinhVien", "HoTen", bAOCAO_SV_NOHP.MaSinhVien);
            return View(bAOCAO_SV_NOHP);
        }

        // GET: BAOCAO_SV_NOHP/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAO_SV_NOHP bAOCAO_SV_NOHP = db.BAOCAO_SV_NOHP.Find(id);
            if (bAOCAO_SV_NOHP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSinhVien = new SelectList(db.HKNHs, "MaHKNH", "HocKy", bAOCAO_SV_NOHP.MaSinhVien);
            ViewBag.MaSinhVien = new SelectList(db.SINHVIENs, "MaSinhVien", "HoTen", bAOCAO_SV_NOHP.MaSinhVien);
            return View(bAOCAO_SV_NOHP);
        }

        // POST: BAOCAO_SV_NOHP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHKNH,MaSinhVien,SoTienConLai")] BAOCAO_SV_NOHP bAOCAO_SV_NOHP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAOCAO_SV_NOHP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSinhVien = new SelectList(db.HKNHs, "MaHKNH", "HocKy", bAOCAO_SV_NOHP.MaSinhVien);
            ViewBag.MaSinhVien = new SelectList(db.SINHVIENs, "MaSinhVien", "HoTen", bAOCAO_SV_NOHP.MaSinhVien);
            return View(bAOCAO_SV_NOHP);
        }

        // GET: BAOCAO_SV_NOHP/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAO_SV_NOHP bAOCAO_SV_NOHP = db.BAOCAO_SV_NOHP.Find(id);
            if (bAOCAO_SV_NOHP == null)
            {
                return HttpNotFound();
            }
            return View(bAOCAO_SV_NOHP);
        }

        // POST: BAOCAO_SV_NOHP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BAOCAO_SV_NOHP bAOCAO_SV_NOHP = db.BAOCAO_SV_NOHP.Find(id);
            db.BAOCAO_SV_NOHP.Remove(bAOCAO_SV_NOHP);
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
