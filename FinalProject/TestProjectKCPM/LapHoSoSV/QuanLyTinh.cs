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
    public class QuanLyTinh
    {
        [Test]
        [TestCase()]
        public void ViewDSTinh()
        {
            TINHsController tinhController = new TINHsController();

            ViewResult result = tinhController.Index() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        //[Test]
        //[TestCase("0039", true)]
        //[TestCase("0099", false)]
        //public void DetailTinh(string MaTinh, bool isNotNull)
        //{
        //    TINHsController tinhController = new TINHsController();

        //    ViewResult result = tinhController.Details(MaTinh) as ViewResult;

        //    if (isNotNull)
        //    {
        //        Assert.IsNotNull(result);
        //        Assert.IsNotNull(result.Model);
        //    }
        //    else
        //    {
        //        Assert.IsNull(result);
        //    }
        //}

        [Test]
        [TestCase()]
        public void CreateViewTinh()
        {
            TINHsController tinhController = new TINHsController();

            ViewResult result = tinhController.Create() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("0002", "Hồ Chí Minh", "Index")]
        [TestCase("02", "Hồ Chí Minh", "Create")]
        [TestCase("000002", "Hồ Chí Minh", "Create")]
        [TestCase("0002", "Hồ Chí Minh Chí Minh Chí Minh Chí Minh Chí Minh Chí Minh Chí Minh Chí Minh", "Create")]
        public void CreatePostTinh(string MaTinh, string TenTinh, string expected)
        {
            TINHsController tinhController = new TINHsController();

            tinhController.DeleteConfirmed(MaTinh);
            TINH tinh = new TINH { 
                MaTinh = MaTinh, 
                TenTinh = TenTinh  
            };
            RedirectToRouteResult result = tinhController.Create(tinh) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("0002", true)]
        [TestCase("0088", false)]
        [TestCase("99", false)]
        [TestCase("0000099", false)]
        public void EditViewTinh(string MaTinh, bool isNotNull)
        {
            TINHsController tinhController = new TINHsController();

            TINH tinh = new TINH { 
                MaTinh = MaTinh, 
                TenTinh = "Hồ Chí Minh" 
            };
            tinhController.DeleteConfirmed(MaTinh);
            if (isNotNull)
            {
                tinhController.Create(tinh);
            }
            ViewResult result = tinhController.Edit(MaTinh) as ViewResult;

            if (isNotNull)
            {
                Assert.IsNotNull(result);
                string expected = "";
                string actual = result.ViewName;
                Assert.AreEqual(expected, actual);
            }
            else
            {
                Assert.IsNull(result);
            }
        }

        [Test]
        [TestCase("0002", "Sài Gòn", "Index")]
        [TestCase("0002", "", "Edit")]
        [TestCase("0002", "TenTinhNew TenTinhNew TenTinhNew TenTinhNew TenTinhNew TenTinhNew TenTinhNew", "Edit")]
        public void EditPostTinh(string MaTinh, string TenTinhNew, string expected)
        {
            TINHsController tinhController = new TINHsController();

            TINH tinh = new TINH { 
                MaTinh = MaTinh, 
                TenTinh = "Hồ Chí Minh" 
            };
            tinhController.Create(tinh);

            tinh.TenTinh = TenTinhNew;
            RedirectToRouteResult result = tinhController.Edit(tinh) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("0002", true)]
        [TestCase("01", false)]
        [TestCase("00002", false)]
        [TestCase("0088", false)]
        public void DeleteViewTinh(string MaTinh, bool isNotNull)
        {
            TINHsController tinhController = new TINHsController();

            TINH tinh = new TINH { MaTinh = MaTinh, TenTinh = "Hồ Chí Minh" };
            if(isNotNull) {
                tinhController.Create(tinh);
            }
            
            ViewResult result = tinhController.Delete(MaTinh) as ViewResult;

            if (isNotNull)
            {
                Assert.IsNotNull(result);
                string expected = "";
                string actual = result.ViewName;
                Assert.AreEqual(expected, actual);
            }
            else
            {
                Assert.IsNull(result);
            }
        }

        [Test]
        [TestCase("0002", "Index")]
        [TestCase("0099", "Delete")]
        [TestCase("01", "Delete")]
        [TestCase("000002", "Delete")]
        public void DeletePostTinh(string MaTinh, string expected)
        {
            TINHsController tinhController = new TINHsController();
            TINH tinh = new TINH { MaTinh = MaTinh, TenTinh = "Hồ Chí Minh" };
            if(expected=="Index")
            {
                tinhController.Create(tinh);
            }
            RedirectToRouteResult result = tinhController.DeleteConfirmed(MaTinh) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
