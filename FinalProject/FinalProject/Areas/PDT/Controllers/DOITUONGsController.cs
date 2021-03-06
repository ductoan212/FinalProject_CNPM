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
    public class DOITUONGsController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        // GET: PDT/DOITUONGs
        public ActionResult Index()
        {
            return View(db.DOITUONGs.ToList());
        }

        // GET: PDT/DOITUONGs/Create
        public ActionResult Create(int id = 0)
        {
            ViewBag.m = "Dung";
            if (id == 1)
                ViewBag.m = "Sai";
            return View();
        }

        // POST: PDT/DOITUONGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDoiTuong,TenDoiTuong,TiLeGiamHocPhi")] DOITUONG dOITUONG)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.DOITUONGs.Add(dOITUONG);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(dOITUONG);
            }
            catch(Exception e)
            {
                return RedirectToAction("Create", "DOITUONGs", new { id = 1 });
            }
        }

        // GET: PDT/DOITUONGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOITUONG dOITUONG = db.DOITUONGs.Find(id);
            if (dOITUONG == null)
            {
                return HttpNotFound();
            }
            return View(dOITUONG);
        }

        // POST: PDT/DOITUONGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDoiTuong,TenDoiTuong,TiLeGiamHocPhi")] DOITUONG dOITUONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOITUONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dOITUONG);
        }

        // GET: PDT/DOITUONGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOITUONG dOITUONG = db.DOITUONGs.Find(id);
            if (dOITUONG == null)
            {
                return HttpNotFound();
            }
            return View(dOITUONG);
        }

        // POST: PDT/DOITUONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                DOITUONG dOITUONG = db.DOITUONGs.Find(id);
                db.DOITUONGs.Remove(dOITUONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Delete", "DOITUONGs", new { id = id });
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
