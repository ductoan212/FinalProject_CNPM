using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using FinalProject.Areas.PDT.Controllers;
using FinalProject.Models;
using System.Web.Mvc;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestProjectKCPM.PhieuDKTest
{
    //[TestClass]
    [TestFixture]
    public class PhieuDKTest
    {
        [Test]
        [TestCase("0", "1003", "2020-05-05", "0120", "Create PHIEU_DK")]
        [TestCase("-1000", "1003", "2020-05-05", "0120", "Create PHIEU_DK")]
        [TestCase("50", "1003", "2020-05-05", "0120", "Create PHIEU_DK")]
        [TestCase("asdf", "1003", "2020-05-05", "0120", "Create PHIEU_DK")]
        [TestCase("1010", "1003", "2020-05-05", "0120", "Create CT_PHIEUDK")]

        public void themPDK_SPDK(string SoPhieuDK, string MaSinhVien, string NgayDK, string MaHKNH, string expected)
        {
            PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

            PHIEU_DK pHIEU_DK = new PHIEU_DK
            {
                SoPhieuDK = SoPhieuDK,
                MaSinhVien = MaSinhVien,
                NgayDK = DateTime.Parse(NgayDK),
                MaHKNH = MaHKNH,
            };
            RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

            Assert.AreEqual(expected, result.RouteValues["action"].ToString() + " " + result.RouteValues["controller"].ToString());
        }

        [Test]
        [TestCase("1006", "0", "2020-05-05", "0120", "Create PHIEU_DK")]
        [TestCase("1006", "-1000", "2020-05-05", "0120", "Create PHIEU_DK")]
        [TestCase("1006", "50", "2020-05-05", "0120", "Create PHIEU_DK")]
        [TestCase("1006", "asdf", "2020-05-05", "0120", "Create PHIEU_DK")]
        [TestCase("1006", "1002", "2020-05-05", "0120", "Create CT_PHIEUDK")]
        public void themPDK_MSV(string SoPhieuDK, string MaSinhVien, string NgayDK, string MaHKNH, string expected)
        {
            PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

            PHIEU_DK pHIEU_DK = new PHIEU_DK
            {
                SoPhieuDK = SoPhieuDK,
                MaSinhVien = MaSinhVien,
                NgayDK = DateTime.Parse(NgayDK),
                MaHKNH = MaHKNH,
            };
            RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

            Assert.AreEqual(expected, result.RouteValues["action"].ToString() + " " + result.RouteValues["controller"].ToString());
        }

        [Test]
        [TestCase("1006", "1003", "2000-04-31", "0120", "Create PHIEU_DK")]
        [TestCase("1006", "1003", "2000-04-30", "0120", "Create CT_PHIEUDK")]
        [TestCase("1006", "1003", "2000-04--1", "0120", "Create PHIEU_DK")]
        [TestCase("1006", "1003", "2001-02-29", "0120", "Create PHIEU_DK")]
        [TestCase("1006", "1003", "2001-02-20", "0120", "Create CT_PHIEUDK")]
        [TestCase("1006", "1003", "2001-02--2", "0120", "Create PHIEU_DK")]
        [TestCase("1006", "1003", "2000-02-30", "0120", "Create PHIEU_DK")]
        [TestCase("1006", "1003", "2000-02-20", "0120", "Create CT_PHIEUDK")]
        [TestCase("1006", "1003", "2000-02--10", "0120", "Create PHIEU_DK")]
        [TestCase("1006", "1003", "2000-03-32", "0120", "Create PHIEU_DK")]
        [TestCase("1006", "1003", "2000-03-30", "0120", "Create CT_PHIEUDK")]
        [TestCase("1006", "1003", "2000-03--1", "0120", "Create PHIEU_DK")]
        public void themPDK_NGDK(string SoPhieuDK, string MaSinhVien, string NgayDK, string MaHKNH, string expected)
        {
            PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

            PHIEU_DK pHIEU_DK = new PHIEU_DK
            {
                SoPhieuDK = SoPhieuDK,
                MaSinhVien = MaSinhVien,
                NgayDK = DateTime.Parse(NgayDK),
                MaHKNH = MaHKNH,
            };
            RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

            Assert.AreEqual(expected, result.RouteValues["action"].ToString() + " " + result.RouteValues["controller"].ToString());
        }

        [Test]
        [TestCase("1006", "1003", "2020-05-05", "-0120", "Create PHIEU_DK")]
        [TestCase("1006", "1003", "2020-05-05", "0", "Create PHIEU_DK")]
        [TestCase("1006", "1003", "2020-05-05", "1234", "Create PHIEU_DK")]
        [TestCase("1006", "1003", "2020-05-05", "0121", "Create CT_PHIEUDK")]
        public void themPDK_MaHKNH(string SoPhieuDK, string MaSinhVien, string NgayDK, string MaHKNH, string expected)
        {
            PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

            PHIEU_DK pHIEU_DK = new PHIEU_DK
            {
                SoPhieuDK = SoPhieuDK,
                MaSinhVien = MaSinhVien,
                NgayDK = DateTime.Parse(NgayDK),
                MaHKNH = MaHKNH,
            };
            RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

            Assert.AreEqual(expected, result.RouteValues["action"].ToString() + " " + result.RouteValues["controller"].ToString());
        }

        [Test]
        [TestCase("1006", "1003", "2020-05-05", "0120", "Create CT_PHIEUDK")]
        [TestCase("1007", "1004", "2020-05-05", "0120", "Create CT_PHIEUDK")]
        [TestCase("1008", "1005", "2020-05-05", "0120", "Create CT_PHIEUDK")]
        [TestCase("1009", "1006", "2020-05-05", "0120", "Create CT_PHIEUDK")]
        [TestCase("1010", "1003", "2020-05-05", "0120", "Create PHIEU_DK")]
        [TestCase("1011", "200", "2020-05-05", "0219", "Create PHIEU_DK")]
        [TestCase("1012", "1002", "2020-05-05", "0320", "Create PHIEU_DK")]
        [TestCase("-1013", "1002", "2020-05-05", "0220", "Create PHIEU_DK")]
        public void themPDK_whiteBox(string SoPhieuDK, string MaSinhVien, string NgayDK, string MaHKNH, string expected)
        {
            PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

            PHIEU_DK pHIEU_DK = new PHIEU_DK
            {
                SoPhieuDK = SoPhieuDK,
                MaSinhVien = MaSinhVien,
                NgayDK = DateTime.Parse(NgayDK),
                MaHKNH = MaHKNH,
            };
            RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

            Assert.AreEqual(expected, result.RouteValues["action"].ToString() + " " + result.RouteValues["controller"].ToString());
        }

        //public void themPhieuDangKi_test(string SoPhieuDK, string MaSinhVien, string NgayDK, string MaHKNH, string expected)
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = SoPhieuDK,
        //        MaSinhVien = MaSinhVien,
        //        NgayDK = DateTime.Parse(NgayDK),
        //        MaHKNH = MaHKNH,
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual(expected, result.RouteValues["action"].ToString() + " " + result.RouteValues["controller"].ToString());
        //}


        //[TestMethod]
        //public void themPhieuDKTest_SPDK_1()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "0",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0120",
        //    };
        //    //RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;
        //    //result.ExecuteResult

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //    //result.
        //}

        //[TestMethod]
        //public void themPhieuDKTest_SPDK_2()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "-1000",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_SPDK_3()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "50",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_SPDK_4()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "asdf",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_SPDK_5()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1010",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create CT_PHIEUDK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_MSV_1()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "0",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_MSV_2()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "-1000",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_MSV_3()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "50",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_MSV_4()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "asdf",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_MSV_5()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1002",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create CT_PHIEUDK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_NgayDK_1()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2000-04-31"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_NgayDK_2()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2000-04-30"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create CT_PHIEUDK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_NgayDK_3()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2000-04--1"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_NgayDK_4()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2001-02-29"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_NgayDK_5()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2001-02-20"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create CT_PHIEUDK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_NgayDK_6()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2001-02--2"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_NgayDK_7()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2000-02-30"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_NgayDK_8()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2000-02-20"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create CT_PHIEUDK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_NgayDK_9()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2000-02--10"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_NgayDK_10()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2000-03-32"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}
        //[TestMethod]
        //public void themPhieuDKTest_NgayDK_11()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2000-03-30"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create CT_PHIEUDK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_NgayDK_12()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2000-03--1"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_MaHKNH_1()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "-0121",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_MaHKNH_2()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_MaHKNH_3()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "1234",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_MaHKNH_4()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0121",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create CT_PHIEUDK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_Success_1()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1006",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create CT_PHIEUDK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_Success_2()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1007",
        //        MaSinhVien = "1004",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create CT_PHIEUDK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_Success_3()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1008",
        //        MaSinhVien = "1005",
        //        NgayDK = DateTime.Parse("2020-05-30"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create CT_PHIEUDK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_Success_4()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1009",
        //        MaSinhVien = "1006",
        //        NgayDK = DateTime.Parse("2020-05-05"),
        //        MaHKNH = "0121",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create CT_PHIEUDK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_Failure_1()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1010",
        //        MaSinhVien = "1003",
        //        NgayDK = DateTime.Parse("7/7/2020 9:50:00 AM"),
        //        MaHKNH = "0120",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_Failure_2()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1011",
        //        MaSinhVien = "200",
        //        NgayDK = DateTime.Parse("2018-09-05"),
        //        MaHKNH = "0219",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_Failure_3()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "1012",
        //        MaSinhVien = "1002",
        //        NgayDK = DateTime.Parse("2018-09-05"),
        //        MaHKNH = "0320",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}

        //[TestMethod]
        //public void themPhieuDKTest_Failure_4()
        //{
        //    PHIEU_DKController pHIEU_DKController = new PHIEU_DKController();

        //    PHIEU_DK pHIEU_DK = new PHIEU_DK
        //    {
        //        SoPhieuDK = "-1013",
        //        MaSinhVien = "1002",
        //        NgayDK = DateTime.Parse("2018-09-05"),
        //        MaHKNH = "0220",
        //    };
        //    RedirectToRouteResult result = pHIEU_DKController.Create(pHIEU_DK) as RedirectToRouteResult;

        //    Assert.AreEqual("Create PHIEU_DK", "Create " + result.RouteValues["controller"].ToString());
        //}
    }
}
