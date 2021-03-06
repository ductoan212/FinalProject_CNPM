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
    public class KHOAsController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        // GET: PDT/KHOAs
        public ActionResult Index()
        {
            return View(db.KHOAs.ToList());
        }

        // GET: PDT/KHOAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOA kHOA = db.KHOAs.Find(id);
            if (kHOA == null)
            {
                return HttpNotFound();
            }
            return View(kHOA);
        }

        // GET: PDT/KHOAs/Create
        public ActionResult Create(int id = 0)
        {
            ViewBag.m = "Dung";
            if (id == 1)
                ViewBag.m = "Sai";
            return View();
        }

        // POST: PDT/KHOAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhoa,TenKhoa")] KHOA kHOA)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.KHOAs.Add(kHOA);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(kHOA);
            }
            catch(Exception e)
            {
                return RedirectToAction("Create", "KHOAs", new { id = 1 });
            }
        }

        // GET: PDT/KHOAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOA kHOA = db.KHOAs.Find(id);
            if (kHOA == null)
            {
                return HttpNotFound();
            }
            return View(kHOA);
        }

        // POST: PDT/KHOAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhoa,TenKhoa")] KHOA kHOA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHOA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kHOA);
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
