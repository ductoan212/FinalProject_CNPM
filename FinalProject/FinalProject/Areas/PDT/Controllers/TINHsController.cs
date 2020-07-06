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
    public class TINHsController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        // GET: PDT/TINHs
        public ActionResult Index()
        {
            return View(db.TINHs.ToList());
        }

        // GET: PDT/TINHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINH tINH = db.TINHs.Find(id);
            if (tINH == null)
            {
                return HttpNotFound();
            }
            return View(tINH);
        }

        // GET: PDT/TINHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PDT/TINHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTinh,TenTinh")] TINH tINH)
        {
            if (ModelState.IsValid)
            {
                db.TINHs.Add(tINH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tINH);
        }

        // GET: PDT/TINHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINH tINH = db.TINHs.Find(id);
            if (tINH == null)
            {
                return HttpNotFound();
            }
            return View(tINH);
        }

        // POST: PDT/TINHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTinh,TenTinh")] TINH tINH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tINH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tINH);
        }

        // GET: PDT/TINHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINH tINH = db.TINHs.Find(id);
            if (tINH == null)
            {
                return HttpNotFound();
            }
            return View(tINH);
        }

        // POST: PDT/TINHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TINH tINH = db.TINHs.Find(id);
            db.TINHs.Remove(tINH);
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
