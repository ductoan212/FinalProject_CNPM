using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FinalProject.Areas.Login.Controllers;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.Areas.PDT.Controllers;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using FinalProject.Areas.Admin.Controllers;

namespace TestProjectKCPM
{
    [TestClass]
    public class QuanLySV
    {
        private CNPMEntities db = new CNPMEntities();

        [TestMethod]
        public void ViewDSSV()
        {
            SINHVIENsController svController = new SINHVIENsController();

            ViewResult result = svController.Index() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DetailSV()
        {
            SINHVIENsController svController = new SINHVIENsController();

            ViewResult result = svController.Details("1001") as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void CreateViewSV()
        {
            SINHVIENsController svController = new SINHVIENsController();

            ViewResult result = svController.Create() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("1010", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "DT02", "CNTT")]
        public void CreatePostSV(string MaSinhVien, string HoTen, string GioiTinh, string NgaySinh,
            string MaHuyen, string MaDoiTuong, string MaNganh)
        {
            SINHVIENsController svController = new SINHVIENsController();
            NGUOIDUNGsController ndController = new NGUOIDUNGsController();

            SINHVIEN sv = new SINHVIEN
            {
                MaSinhVien = MaSinhVien,
                HoTen = HoTen,
                GioiTinh = GioiTinh,
                NgaySinh = Convert.ToDateTime(NgaySinh),
                MaHuyen = MaHuyen,
                MaDoiTuong = MaDoiTuong,
                MaNganh = MaNganh
            };

            svController.DeleteConfirmed(MaSinhVien);
            ndController.DeleteConfirmed(MaSinhVien);

            RedirectToRouteResult result = svController.Create(sv) as RedirectToRouteResult;
            
            Assert.IsNotNull(result);
            string expected = "Index";
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditViewSV()
        {
            SINHVIENsController svController = new SINHVIENsController();

            ViewResult result = svController.Edit("1001") as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("1001")]
        public void EditPostSV(string MaSinhVien)
        {
            SINHVIENsController svController = new SINHVIENsController();

            SINHVIEN sv = svController.GetSINHVIEN(MaSinhVien);
            sv.HoTen = "TEST EDIT";
            RedirectToRouteResult result = svController.Edit(sv) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string expected = "Index";
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
