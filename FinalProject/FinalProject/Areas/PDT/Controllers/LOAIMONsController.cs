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
    public class LOAIMONsController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        // GET: PDT/LOAIMONs
        public ActionResult Index()
        {
            return View(db.LOAIMONs.ToList());
        }

        // GET: PDT/LOAIMONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIMON lOAIMON = db.LOAIMONs.Find(id);
            if (lOAIMON == null)
            {
                return HttpNotFound();
            }
            return View(lOAIMON);
        }

        // GET: PDT/LOAIMONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PDT/LOAIMONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiMon,TenLoaiMon,SoTietTC,SoTienTC")] LOAIMON lOAIMON)
        {
            if (ModelState.IsValid)
            {
                db.LOAIMONs.Add(lOAIMON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAIMON);
        }

        // GET: PDT/LOAIMONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIMON lOAIMON = db.LOAIMONs.Find(id);
            if (lOAIMON == null)
            {
                return HttpNotFound();
            }
            return View(lOAIMON);
        }

        // POST: PDT/LOAIMONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiMon,TenLoaiMon,SoTietTC,SoTienTC")] LOAIMON lOAIMON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAIMON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAIMON);
        }

        // GET: PDT/LOAIMONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIMON lOAIMON = db.LOAIMONs.Find(id);
            if (lOAIMON == null)
            {
                return HttpNotFound();
            }
            return View(lOAIMON);
        }

        // POST: PDT/LOAIMONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAIMON lOAIMON = db.LOAIMONs.Find(id);
            db.LOAIMONs.Remove(lOAIMON);
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
