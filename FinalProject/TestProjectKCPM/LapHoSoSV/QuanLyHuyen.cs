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
    public class QuanLyHuyen
    {
        [Test]
        [TestCase()]
        public void ViewDSHuyen()
        {
            HUYENsController huyenController = new HUYENsController();

            ViewResult result = huyenController.Index() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        //[Test]
        //[TestCase("3901", true)]
        //[TestCase("0001", false)]
        //public void DetailHuyen(string MaHuyen, bool isNotNull)
        //{
        //    HUYENsController huyenController = new HUYENsController();

        //    ViewResult result = huyenController.Details(MaHuyen) as ViewResult;

        //    if(isNotNull)
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
        public void CreateViewHuyen()
        {
            HUYENsController huyenController = new HUYENsController();

            ViewResult result = huyenController.Create() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("3910", "Tuy An", "0039", true, "Index")]
        [TestCase("3910", "Tuy An", "0099", true, "Create")]
        [TestCase("39100", "Tuy An", "0039", true, "Create")]
        [TestCase("391", "Tuy An", "0039", true, "Create")]
        public void CreatePostHuyen(
            string MaHuyen, string TenHuyen, 
            string MaTinh, bool UuTien, 
            string expected)
        {
            HUYENsController huyenController = new HUYENsController();

            huyenController.DeleteConfirmed(MaHuyen);
            HUYEN huyen = new HUYEN { 
                MaHuyen = MaHuyen, 
                TenHuyen = TenHuyen, 
                MaTinh = MaTinh, 
                UuTien = UuTien
            };
            RedirectToRouteResult result = huyenController.Create(huyen) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("3910", true)]
        [TestCase("9999", false)]
        public void EditViewHuyen(string MaHuyen, bool isNotNull)
        {
            HUYENsController huyenController = new HUYENsController();

            HUYEN huyen = new HUYEN { 
                MaHuyen = MaHuyen, 
                TenHuyen = "Tuy An", 
                MaTinh = "0039", 
                UuTien = true 
            };
            if(isNotNull)
            {
                huyenController.Create(huyen);
            }
            ViewResult result = huyenController.Edit(MaHuyen) as ViewResult;

            if(isNotNull)
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
        [TestCase("3910", "Song Hinh", "0039", "Index")]
        [TestCase("3910", "Song Hinh", "0099", "Edit")]
        [TestCase("3910", "", "0099", "Edit")]
        [TestCase("3910", "Song Hinh Song Hinh Song Hinh Song Hinh Song Hinh Song Hinh Song Hinh", "0099", "Edit")]
        public void EditPostHuyen(string MaHuyen, string TenHuyenNew, string MaTinhNew, string expected)
        {
            HUYENsController huyenController = new HUYENsController();

            HUYEN huyen = new HUYEN { 
                MaHuyen = MaHuyen, 
                TenHuyen = "Tuy An", 
                MaTinh = "0039", 
                UuTien = true 
            };
            huyenController.Create(huyen);

            huyen.TenHuyen = TenHuyenNew;
            huyen.MaTinh= MaTinhNew;
            RedirectToRouteResult result = huyenController.Edit(huyen) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("3910", true)]
        [TestCase("9999", false)]
        public void DeleteViewHuyen(string MaHuyen, bool isNotNull)
        {
            HUYENsController huyenController = new HUYENsController();

            HUYEN huyen = new HUYEN
            {
                MaHuyen = MaHuyen,
                TenHuyen = "Tuy An",
                MaTinh = "0039",
                UuTien = true
            };
            if(isNotNull)
            {
                huyenController.Create(huyen);
            }
            ViewResult result = huyenController.Delete(MaHuyen) as ViewResult;

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
        [TestCase("3910", "Index")]
        [TestCase("3999", "Delete")]
        public void DeletePostHuyen(string MaHuyen, string expected)
        {
            HUYENsController huyenController = new HUYENsController();

            
            HUYEN huyen = new HUYEN
            {
                MaHuyen = MaHuyen,
                TenHuyen = "Tuy An",
                MaTinh = "0039",
                UuTien = true
            };
            if (expected == "Index")
            {
                huyenController.Create(huyen);
            }

            RedirectToRouteResult result = huyenController.DeleteConfirmed(MaHuyen) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
