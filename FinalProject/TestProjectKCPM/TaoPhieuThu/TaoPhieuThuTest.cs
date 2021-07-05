using NUnit.Framework;
using FinalProject.Areas.PDT.Controllers;
using System.Web.Mvc;
using FinalProject.Models;
using System;

namespace TestProjectKCPM.TaoPhieuThu
{
    [TestFixture]
    public class TaoPhieuThuTest
    {
        [Test]
        [TestCase(0, "", "")]
        [TestCase(1, "", "")]
        public void ThemPhieuThu(int id, string id_pt, string expected)
        {
            PHIEUTHUsController pHIEUTHUsController = new PHIEUTHUsController();
            var result = pHIEUTHUsController.Create(id, id_pt) as ViewResult;
            Assert.AreEqual(result.ViewName, expected);
        }
        [Test]
        [TestCase("1001", "25/10/2020", 10000, "Index")]
        [TestCase("", "25/10/2020", 10000, "Create")]
        [TestCase("1009", "25/10/2020", 10000, "Create")]
        [TestCase("1001", "32/1/2020", 10000, "Create")]
        [TestCase("1001", "31/2/2020", 10000, "Create")]
        [TestCase("1002", "25/10/2020", 500000, "Create")]
        [TestCase("1002", "25/10/2020", -500000, "Create")]
        public void ThemPhieuThuPost(string SoPhieuDK, string NgayLap, decimal SoTienThu, string expected)
        {
            PHIEUTHUsController pHIEUTHUsController = new PHIEUTHUsController();
            PHIEUTHU pHIEUTHU = new PHIEUTHU
            {
                SoPhieuThu = "",
                SoPhieuDK = SoPhieuDK,
                NgayLap = Convert.ToDateTime(NgayLap),
                SoTienThu = SoTienThu,
            };
            pHIEUTHUsController.Create(0, pHIEUTHU.SoPhieuThu);
            var result = pHIEUTHUsController.Create(pHIEUTHU) as RedirectToRouteResult;
            Assert.AreEqual(result.RouteValues["action"].ToString(), expected);
        }
    }
}
