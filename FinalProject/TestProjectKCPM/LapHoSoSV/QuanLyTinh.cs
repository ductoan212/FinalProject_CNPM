using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FinalProject.Areas.Login.Controllers;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.Areas.PDT.Controllers;

namespace TestProjectKCPM
{
    [TestClass]
    public class QuanLyTinh
    {
        [TestMethod]
        public void ViewDSTinh()
        {
            TINHsController tinhController = new TINHsController();

            ViewResult result = tinhController.Index() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DetailTinh()
        {
            TINHsController tinhController = new TINHsController();

            ViewResult result = tinhController.Details("0039") as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void CreateViewTinh()
        {
            TINHsController tinhController = new TINHsController();

            ViewResult result = tinhController.Create() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreatePostTinh()
        {
            TINHsController tinhController = new TINHsController();

            tinhController.DeleteConfirmed("0002");
            TINH tinh = new TINH { MaTinh = "0002", TenTinh = "Hồ Chí Minh" };
            RedirectToRouteResult result = tinhController.Create(tinh) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string expected = "Index";
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditViewTinh()
        {
            TINHsController tinhController = new TINHsController();

            TINH tinh = new TINH { MaTinh = "0002", TenTinh = "Hồ Chí Minh" };
            tinhController.Create(tinh);
            ViewResult result = tinhController.Edit("0002") as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditPostTinh()
        {
            TINHsController tinhController = new TINHsController();

            TINH tinh = new TINH { MaTinh = "0002", TenTinh = "Hồ Chí Minh" };
            tinhController.Create(tinh);
            tinh.TenTinh = "TP Hồ Chí Minh";
            RedirectToRouteResult result = tinhController.Edit(tinh) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string expected = "Index";
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteViewTinh()
        {
            TINHsController tinhController = new TINHsController();

            TINH tinh = new TINH { MaTinh = "0002", TenTinh = "Hồ Chí Minh" };
            tinhController.Create(tinh);
            ViewResult result = tinhController.Delete("0002") as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeletePostTinh()
        {
            TINHsController tinhController = new TINHsController();
            TINH tinh = new TINH { MaTinh = "0002", TenTinh = "Hồ Chí Minh" };
            tinhController.Create(tinh);
            RedirectToRouteResult result = tinhController.DeleteConfirmed("0002") as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string expected = "Index";
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

    }
}
