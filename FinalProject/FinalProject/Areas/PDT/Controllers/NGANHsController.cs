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
    public class NGANHsController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        // GET: PDT/NGANHs
        public ActionResult Index()
        {
            var nGANHs = db.NGANHs.Include(n => n.KHOA);
            return View(nGANHs.ToList());
        }

        // GET: PDT/NGANHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGANH nGANH = db.NGANHs.Find(id);
            if (nGANH == null)
            {
                return HttpNotFound();
            }
            return View(nGANH);
        }

        // GET: PDT/NGANHs/Create
        public ActionResult Create(int id = 0)
        {
            ViewBag.m = "Dung";
            if (id == 1)
                ViewBag.m = "Sai";
            ViewBag.MaKhoa = new SelectList(db.KHOAs, "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: PDT/NGANHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNganh,MaKhoa,TenNganh")] NGANH nGANH)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.NGANHs.Add(nGANH);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.MaKhoa = new SelectList(db.KHOAs, "MaKhoa", "TenKhoa", nGANH.MaKhoa);
                return View(nGANH);
            }
            catch(Exception e)
            {
                return RedirectToAction("Create", "NGANHs", new { id = 1 });
            }
        }

        // GET: PDT/NGANHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGANH nGANH = db.NGANHs.Find(id);
            if (nGANH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhoa = new SelectList(db.KHOAs, "MaKhoa", "TenKhoa", nGANH.MaKhoa);
            return View(nGANH);
        }

        // POST: PDT/NGANHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNganh,MaKhoa,TenNganh")] NGANH nGANH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGANH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoa = new SelectList(db.KHOAs, "MaKhoa", "TenKhoa", nGANH.MaKhoa);
            return View(nGANH);
        }

        // GET: PDT/NGANHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGANH nGANH = db.NGANHs.Find(id);
            if (nGANH == null)
            {
                return HttpNotFound();
            }
            return View(nGANH);
        }

        // POST: PDT/NGANHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NGANH nGANH = db.NGANHs.Find(id);
            db.NGANHs.Remove(nGANH);
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
