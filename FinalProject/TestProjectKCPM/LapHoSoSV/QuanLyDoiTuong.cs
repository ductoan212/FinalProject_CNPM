using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FinalProject.Areas.Login.Controllers;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.Areas.PDT.Controllers;

namespace TestProjectKCPM
{
    [TestClass]
    public class QuanLyDoiTuong
    {
        [TestMethod]
        public void ViewDSDoiTuong()
        {
            DOITUONGsController doituongController = new DOITUONGsController();

            ViewResult result = doituongController.Index() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateViewDoiTuong()
        {
            DOITUONGsController doituongController = new DOITUONGsController();

            ViewResult result = doituongController.Create() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreatePostDoiTuong()
        {
            DOITUONGsController doituongController = new DOITUONGsController();

            doituongController.DeleteConfirmed("DT07");
            DOITUONG doituong = new DOITUONG { MaDoiTuong = "DT07", TenDoiTuong = "Đối tượng test", TiLeGiamHocPhi = 10 };
            RedirectToRouteResult result = doituongController.Create(doituong) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string expected = "Index";
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditViewDoiTuong()
        {
            DOITUONGsController doituongController = new DOITUONGsController();

            DOITUONG doituong = new DOITUONG { MaDoiTuong = "DT07", TenDoiTuong = "Đối tượng test", TiLeGiamHocPhi = 10 };
            doituongController.Create(doituong);
            ViewResult result = doituongController.Edit("DT07") as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditPostDoiTuong()
        {
            DOITUONGsController doituongController = new DOITUONGsController();

            DOITUONG doituong = new DOITUONG { MaDoiTuong = "DT07", TenDoiTuong = "Đối tượng test", TiLeGiamHocPhi = 10 };
            doituongController.Create(doituong);
            doituong.TenDoiTuong = "Đối tượng sửa";
            RedirectToRouteResult result = doituongController.Edit(doituong) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string expected = "Index";
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteViewDoiTuong()
        {
            DOITUONGsController doituongController = new DOITUONGsController();

            DOITUONG doituong = new DOITUONG { MaDoiTuong = "DT07", TenDoiTuong = "Đối tượng test", TiLeGiamHocPhi = 10 };
            doituongController.Create(doituong);
            ViewResult result = doituongController.Delete("DT07") as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeletePostDoiTuong()
        {
            DOITUONGsController doituongController = new DOITUONGsController();
            DOITUONG doituong = new DOITUONG { MaDoiTuong = "DT07", TenDoiTuong = "Đối tượng test", TiLeGiamHocPhi = 10 };
            doituongController.Create(doituong);
            RedirectToRouteResult result = doituongController.DeleteConfirmed("DT07") as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string expected = "Index";
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

    }
}
