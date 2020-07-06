using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FinalProject.Models;

namespace FinalProject.Areas.PDT.Controllers
{
    public class DS_MONHOC_MOController : Controller
    {
        private CNPMEntities db = new CNPMEntities();
        private static string hk;

        // GET: DS_MONHOC_MO
        public ActionResult Index(string id)
        {
            var dS_MONHOC_MO = db.DS_MONHOC_MO.Include(d => d.HKNH).Include(d => d.MONHOC).Where(d => d.MaHKNH == id);
            var first = db.DS_MONHOC_MO.FirstOrDefault(d => d.MaHKNH == id);
            ViewBag.TenHK = db.HKNHs.Where(m => m.MaHKNH == id).FirstOrDefault();
            return View(dS_MONHOC_MO.ToList());
        }

        public ActionResult ListHK()
        {
            ViewBag.ListHK = db.HKNHs.ToList();
            return View();
        }


        // GET: DS_MONHOC_MO/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DS_MONHOC_MO dS_MONHOC_MO = db.DS_MONHOC_MO.Find(id);
            if (dS_MONHOC_MO == null)
            {
                return HttpNotFound();
            }
            return View(dS_MONHOC_MO);
        }

        // GET: DS_MONHOC_MO/Create
        public ActionResult Create(string hknh,int isErr = 0)
        {
            ViewBag.ListHK = db.HKNHs.ToList();
            //ViewBag.MaMonHoc = new SelectList(db.MONHOCs, "MaMonHoc", "TenMonHoc");
            ViewBag.IsErr = isErr;
            return View();
        }
        public ActionResult List(string MaMo = null, string MaHKNH = null, int isNull = 0)
        {

            ViewBag.MaHKNH = new SelectList(db.HKNHs, "MaHKNH", "HocKy");
            ViewBag.MaMonHoc = new SelectList(db.MONHOCs, "MaMonHoc", "TenMonHoc");

            List<MONHOC> list_mh = new List<MONHOC>();
            var da_mo = db.DS_MONHOC_MO.Where(m => m.MaHKNH == MaHKNH);
            foreach (MONHOC item in db.MONHOCs)
            {
                if (da_mo.Where(m => m.MaMonHoc == item.MaMonHoc).Count() == 0)
                    list_mh.Add(item);
            }

            //ViewBag.MonHoc = db.MONHOCs.ToList();
            ViewBag.MonHoc = list_mh.ToList();
            ViewBag.DS_MonHoc = db.DS_MONHOC_MO.ToList();
            ViewBag.MaMo = MaMo;
            ViewBag.MaHKNH = MaHKNH;
            ViewBag.IsNull = isNull;
            if (MaHKNH != null)
                hk = MaHKNH;
            var mONHOCs = db.MONHOCs;
            return View();
        }

        // POST: DS_MONHOC_MO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMo,MaHKNH")] DS_MONHOC_MO dS_MONHOC_MO)
        {
            if (db.HKNHs.Where(m => m.MaHKNH == dS_MONHOC_MO.MaHKNH).Count() == 0)
                return RedirectToAction("Create", new { @isErr = 1 });
            if (ModelState.IsValid)
            {
                var MaMo_last = db.DS_MONHOC_MO.OrderByDescending(p => p.MaMo).FirstOrDefault();
                int id_num;
                if (MaMo_last == null)
                {
                    id_num = 1001;
                }
                else
                    id_num = Int32.Parse(MaMo_last.MaMo) + 1;
                //db.DS_MONHOC_MO.Add(dS_MONHOC_MO);
                //db.SaveChanges();
                //return RedirectToAction("List", dS_MONHOC_MO);
                return RedirectToAction("List", "DS_MONHOC_MO", new { @MaMo = id_num.ToString(), @MaHKNH = dS_MONHOC_MO.MaHKNH.ToString() });
            }

            ViewBag.MaHKNH = new SelectList(db.HKNHs, "MaHKNH", "HocKy", dS_MONHOC_MO.MaHKNH);
            //ViewBag.MaMonHoc = new SelectList(db.MONHOCs, "MaMonHoc", "TenMonHoc", dS_MONHOC_MO.MaMonHoc);
            return View(dS_MONHOC_MO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.MaHKNH = new SelectList(db.HKNHs, "MaHKNH", "HocKy", dS_MONHOC_MO.MaHKNH);
                var MaMo_last = db.DS_MONHOC_MO.OrderByDescending(p => p.MaMo).FirstOrDefault();
                int id_MaMo = 1001;
                if (MaMo_last == null)
                {
                    id_MaMo = 1001;
                }
                else
                    id_MaMo = Int32.Parse(MaMo_last.MaMo);
                //int id_num = Int32.Parse(MaMo_last.MaMo) + 1;
                //var employee = db.DS_MONHOC_MO.SingleOrDefault(p => p.MaMonHoc == id);
                string[] ids = formCollection["ID"]?.Split(new char[] { ',' });
                if (ids == null)
                {
                    ViewBag.IsNull = 1;
                    return RedirectToAction("Index", new { id = hk });
                }
                try
                {
                    foreach (string id in ids)
                    {

                        DS_MONHOC_MO a = new DS_MONHOC_MO()
                        {
                            MaMo = (++id_MaMo).ToString(),
                            MaHKNH = hk,
                            MaMonHoc = id
                        };
                        //db.DS_MONHOC_MO.Remove(employee);
                        //employee.MaMo = (Int32.Parse(employee.MaMo) + 1).ToString();
                        db.DS_MONHOC_MO.Add(a);
                        db.SaveChanges();
                    }
                }
                catch
                {
                    ViewBag.err = 1;
                    return RedirectToAction("Create", new { @isErr = ViewBag.err });

                }
                //db.DS_MONHOC_MO.Add(dS_MONHOC_MO);
                //db.SaveChanges();
                return RedirectToAction("Index", new { id = hk });
            }

            //ViewBag.MaHKNH = new SelectList(db.HKNHs, "MaHKNH", "HocKy", dS_MONHOC_MO.MaHKNH);
            //ViewBag.MaMonHoc = new SelectList(db.MONHOCs, "MaMonHoc", "TenMonHoc", dS_MONHOC_MO.MaMonHoc);
            return View();
        }

        // GET: DS_MONHOC_MO/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DS_MONHOC_MO dS_MONHOC_MO = db.DS_MONHOC_MO.Find(id);
            if (dS_MONHOC_MO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHKNH = new SelectList(db.HKNHs, "MaHKNH", "HocKy", dS_MONHOC_MO.MaHKNH);
            ViewBag.MaMonHoc = new SelectList(db.MONHOCs, "MaMonHoc", "TenMonHoc", dS_MONHOC_MO.MaMonHoc);
            return View(dS_MONHOC_MO);
        }

        // POST: DS_MONHOC_MO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMo,MaHKNH,MaMonHoc")] DS_MONHOC_MO dS_MONHOC_MO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dS_MONHOC_MO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHKNH = new SelectList(db.HKNHs, "MaHKNH", "HocKy", dS_MONHOC_MO.MaHKNH);
            ViewBag.MaMonHoc = new SelectList(db.MONHOCs, "MaMonHoc", "TenMonHoc", dS_MONHOC_MO.MaMonHoc);
            return View(dS_MONHOC_MO);
        }

        // GET: DS_MONHOC_MO/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DS_MONHOC_MO dS_MONHOC_MO = db.DS_MONHOC_MO.Find(id);
            if (dS_MONHOC_MO == null)
            {
                return HttpNotFound();
            }
            return View(dS_MONHOC_MO);
        }

        // POST: DS_MONHOC_MO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DS_MONHOC_MO dS_MONHOC_MO = db.DS_MONHOC_MO.Find(id);
            string hknh = dS_MONHOC_MO.MaHKNH.ToString();
            db.DS_MONHOC_MO.Remove(dS_MONHOC_MO);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = hknh });
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
