using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FinalProject.Areas.Login.Controllers;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.Areas.PDT.Controllers;

namespace TestProjectKCPM
{
    [TestClass]
    public class QuanLyHuyen
    {
        [TestMethod]
        public void ViewDSHuyen()
        {
            HUYENsController huyenController = new HUYENsController();

            ViewResult result = huyenController.Index() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DetailHuyen()
        {
            HUYENsController huyenController = new HUYENsController();

            ViewResult result = huyenController.Details("3901") as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void CreateViewHuyen()
        {
            HUYENsController huyenController = new HUYENsController();

            ViewResult result = huyenController.Create() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreatePostHuyen()
        {
            HUYENsController huyenController = new HUYENsController();

            huyenController.DeleteConfirmed("3910");
            HUYEN huyen = new HUYEN { MaHuyen="3910", TenHuyen = "Tuy An", MaTinh="0039", UuTien=true };
            RedirectToRouteResult result = huyenController.Create(huyen) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string expected = "Index";
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditViewHuyen()
        {
            HUYENsController huyenController = new HUYENsController();

            HUYEN huyen = new HUYEN { MaHuyen = "3910", TenHuyen = "Tuy An", MaTinh = "0039", UuTien = true };
            huyenController.Create(huyen);
            ViewResult result = huyenController.Edit("3910") as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditPostHuyen()
        {
            HUYENsController huyenController = new HUYENsController();

            HUYEN huyen = new HUYEN { MaHuyen = "3910", TenHuyen = "Tuy An", MaTinh = "0039", UuTien = true };
            huyenController.Create(huyen);
            huyen.TenHuyen = "Song Hinh";
            RedirectToRouteResult result = huyenController.Edit(huyen) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string expected = "Index";
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteViewHuyen()
        {
            HUYENsController huyenController = new HUYENsController();

            HUYEN huyen = new HUYEN { MaHuyen = "3910", TenHuyen = "Tuy An", MaTinh = "0039", UuTien = true };
            huyenController.Create(huyen);
            ViewResult result = huyenController.Delete("3910") as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeletePostHuyen()
        {
            HUYENsController huyenController = new HUYENsController();
            HUYEN huyen = new HUYEN { MaHuyen = "3910", TenHuyen = "Tuy An", MaTinh = "0039", UuTien = true };
            huyenController.Create(huyen);
            RedirectToRouteResult result = huyenController.DeleteConfirmed("3910") as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string expected = "Index";
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

    }
}
