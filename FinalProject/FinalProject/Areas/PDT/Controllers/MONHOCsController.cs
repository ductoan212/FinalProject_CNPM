﻿using System;
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
    public class MONHOCsController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        // GET: PDT/MONHOCs
        public ActionResult Index()
        {
            var mONHOCs = db.MONHOCs.Include(m => m.LOAIMON);
            return View(mONHOCs.ToList());
        }

        // GET: PDT/MONHOCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONHOC mONHOC = db.MONHOCs.Find(id);
            if (mONHOC == null)
            {
                return HttpNotFound();
            }
            return View(mONHOC);
        }

        // GET: PDT/MONHOCs/Create
        public ActionResult Create(int id = 0)
        {
            ViewBag.m = "Dung";
            if (id == 1)
                ViewBag.m = "Sai";
            ViewBag.MaLoaiMon = new SelectList(db.LOAIMONs, "MaLoaiMon", "TenLoaiMon");
            return View();
        }

        // POST: PDT/MONHOCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "MaMonHoc,TenMonHoc,MaLoaiMon,SoTiet")] MONHOC mONHOC)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.MONHOCs.Add(mONHOC);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.MaLoaiMon = new SelectList(db.LOAIMONs, "MaLoaiMon", "TenLoaiMon", mONHOC.MaLoaiMon);
                return View(mONHOC);
            }
            catch(Exception e)
            {
                return RedirectToAction("Create", "MONHOCs", new { id = 1 });
            }
        }

        // GET: PDT/MONHOCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONHOC mONHOC = db.MONHOCs.Find(id);
            if (mONHOC == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiMon = new SelectList(db.LOAIMONs, "MaLoaiMon", "TenLoaiMon", mONHOC.MaLoaiMon);
            return View(mONHOC);
        }

        // POST: PDT/MONHOCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMonHoc,TenMonHoc,MaLoaiMon,SoTiet")] MONHOC mONHOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mONHOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiMon = new SelectList(db.LOAIMONs, "MaLoaiMon", "TenLoaiMon", mONHOC.MaLoaiMon);
            return View(mONHOC);
        }

        // GET: PDT/MONHOCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONHOC mONHOC = db.MONHOCs.Find(id);
            if (mONHOC == null)
            {
                return HttpNotFound();
            }
            return View(mONHOC);
        }

        // POST: PDT/MONHOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MONHOC mONHOC = db.MONHOCs.Find(id);
            db.MONHOCs.Remove(mONHOC);
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
