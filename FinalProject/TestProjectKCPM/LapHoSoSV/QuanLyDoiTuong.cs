using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FinalProject.Areas.Login.Controllers;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.Areas.PDT.Controllers;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace TestProjectKCPM
{
    [TestClass]
    public class QuanLyDoiTuong
    {
        [Test]
        [TestCase()]
        public void ViewDSDoiTuong()
        {
            DOITUONGsController doituongController = new DOITUONGsController();

            ViewResult result = doituongController.Index() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase()]
        public void CreateViewDoiTuong()
        {
            DOITUONGsController doituongController = new DOITUONGsController();

            ViewResult result = doituongController.Create() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("DT07", "Đối tượng test", 10, "Index")]
        [TestCase("DT08", "Đối tượng DD08", 50, "Index")]
        [TestCase("DT", "Đối tượng test", 50, "Create")]
        [TestCase("DT151515151", "Đối tượng test", 50, "Create")]
        [TestCase("DT07", "Đối tượng test", -5, "Create")]
        [TestCase("DT08", "Đối tượng DD08", 110, "Create")]
        public void CreatePostDoiTuong(string MaDoiTuong, string TenDoiTuong, int TiLeGiamHocPhi, string expected)
        {
            DOITUONGsController doituongController = new DOITUONGsController();

            doituongController.DeleteConfirmed(MaDoiTuong);
            DOITUONG doituong = new DOITUONG { 
                MaDoiTuong = MaDoiTuong, 
                TenDoiTuong = TenDoiTuong, 
                TiLeGiamHocPhi = TiLeGiamHocPhi
            };
            RedirectToRouteResult result = doituongController.Create(doituong) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("DT07")]
        public void EditViewDoiTuong(string MaDoiTuong)
        {
            DOITUONGsController doituongController = new DOITUONGsController();

            DOITUONG doituong = new DOITUONG { 
                MaDoiTuong = MaDoiTuong, 
                TenDoiTuong = "Đối tượng test", 
                TiLeGiamHocPhi = 10 
            };
            doituongController.Create(doituong);
            ViewResult result = doituongController.Edit(MaDoiTuong) as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("DT07", 50, "Index")]
        [TestCase("DT07", -1, "Edit")]
        [TestCase("DT07", 101, "Edit")]
        public void EditPostDoiTuong(string MaDoiTuongOld, int TiLeGiamHocPhiNew, string expected)
        {
            DOITUONGsController doituongController = new DOITUONGsController();

            DOITUONG doituong = new DOITUONG { 
                MaDoiTuong = MaDoiTuongOld, 
                TenDoiTuong = "Đối tượng test", 
                TiLeGiamHocPhi = 10 
            };
            doituongController.Create(doituong);

            doituong.TenDoiTuong = "Đối tượng sửa";
            doituong.TiLeGiamHocPhi = TiLeGiamHocPhiNew;

            RedirectToRouteResult result = doituongController.Edit(doituong) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("DT07")]
        [TestCase("DT01")]
        public void DeleteViewDoiTuong(string MaDoiTuong)
        {
            DOITUONGsController doituongController = new DOITUONGsController();

            DOITUONG doituong = new DOITUONG { 
                MaDoiTuong = MaDoiTuong, 
                TenDoiTuong = "Đối tượng test", 
                TiLeGiamHocPhi = 10 
            };
            doituongController.Create(doituong);
            ViewResult result = doituongController.Delete(MaDoiTuong) as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("DT90", "Index")]
        [TestCase("DT90", "Delete")]
        public void DeletePostDoiTuong(string MaDoiTuong, string expected)
        {
            DOITUONGsController doituongController = new DOITUONGsController();
            DOITUONG doituong = new DOITUONG
            {
                MaDoiTuong = MaDoiTuong,
                TenDoiTuong = "Đối tượng test",
                TiLeGiamHocPhi = 10
            };
            if(expected== "Index")
                doituongController.Create(doituong);
            RedirectToRouteResult result = doituongController.DeleteConfirmed(MaDoiTuong) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
