using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using FinalProject.Areas.PDT.Controllers;
using FinalProject.Models;
using NUnit.Framework;
using System.Web.Mvc;
using Assert = NUnit.Framework.Assert;

namespace TestProjectKCPM.BaoCaoNoTest
{
    [TestFixture]
    public class BaoCaoNoTest
    {
        [Test]
        [TestCase("asdf", "1003", 2000000, "Create")]
        [TestCase("-0120", "1003", 2000000, "Create")]
        [TestCase("0", "1003", 2000000, "Create")]
        [TestCase("0111", "1003", 2000000, "Create")]
        // Thất bại do các MaHKNH trên không nằm trong select list của HKNH
        [TestCase("0120", "1003", 2000000, "Index")]
        // Thành công do phù hợp MaSinhVien, MaHKNH, SoTienConLai
        [TestCase("0120", "1003", 2000000, "Create")]
        // Thất bại do duplicate với trên
        public void LapBaoCaoNoTest_MaHKNH(string MaHKNH, string MaSinhVien, decimal SoTienConLai, string expected)
        {
            BAOCAO_SV_NOHPController bAOCAO_SV_NOHPController = new BAOCAO_SV_NOHPController();
            BAOCAO_SV_NOHP bAOCAO_SV_NOHP = new BAOCAO_SV_NOHP
            {
                MaHKNH = MaHKNH,
                MaSinhVien = MaSinhVien,
                SoTienConLai = SoTienConLai,
            };
            RedirectToRouteResult result = bAOCAO_SV_NOHPController.Create(bAOCAO_SV_NOHP) as RedirectToRouteResult;
            Assert.AreEqual(expected, result.RouteValues["action"].ToString());
        }

        [Test]
        [TestCase("0120", "asdf", 2000000, "Create")]
        [TestCase("0120", "-1002", 2000000, "Create")]
        [TestCase("0120", "0", 2000000, "Create")]
        [TestCase("0120", "100", 2000000, "Create")]
        // Thất bại do các MaSinhVien trên không nằm trong select list của SINHVIEN
        [TestCase("0120", "1002", 2000000, "Index")]
        // Thành công do phù hợp MaSinhVien, MaHKNH, SoTienConLai
        [TestCase("0120", "1002", 2000000, "Create")]
        // Thất bại do duplicate với trên
        public void LapBaoCaoNoTest_MaSinhVien(string MaHKNH, string MaSinhVien, decimal SoTienConLai, string expected)
        {
            BAOCAO_SV_NOHPController bAOCAO_SV_NOHPController = new BAOCAO_SV_NOHPController();
            BAOCAO_SV_NOHP bAOCAO_SV_NOHP = new BAOCAO_SV_NOHP
            {
                MaHKNH = MaHKNH,
                MaSinhVien = MaSinhVien,
                SoTienConLai = SoTienConLai,
            };
            RedirectToRouteResult result = bAOCAO_SV_NOHPController.Create(bAOCAO_SV_NOHP) as RedirectToRouteResult;
            Assert.AreEqual(expected, result.RouteValues["action"].ToString());
        }

        [Test]
        [TestCase("0120", "1003", -2000000, "Create")]
        [TestCase("0120", "1003", 0, "Index")]
        // Thất bại do SoTienConLai phải > 0
        [TestCase("0120", "1003", 100, "Index")]
        [TestCase("0120", "1003", 2000000, "Index")]
        // Thành công do phù hợp MaSinhVien, MaHKNH, SoTienConLai
        [TestCase("0120", "1003", 2000000, "Create")]
        // Thất bại do duplicate với trên
        public void LapBaoCaoNoTest_SoTien(string MaHKNH, string MaSinhVien, decimal SoTienConLai, string expected)
        {
            BAOCAO_SV_NOHPController bAOCAO_SV_NOHPController = new BAOCAO_SV_NOHPController();
            BAOCAO_SV_NOHP bAOCAO_SV_NOHP = new BAOCAO_SV_NOHP
            {
                MaHKNH = MaHKNH,
                MaSinhVien = MaSinhVien,
                SoTienConLai = SoTienConLai,
            };
            RedirectToRouteResult result = bAOCAO_SV_NOHPController.Create(bAOCAO_SV_NOHP) as RedirectToRouteResult;
            Assert.AreEqual(expected, result.RouteValues["action"].ToString());
        }

        [Test]
        [TestCase("0118", "1003", 1000000, "Index")]
        [TestCase("0119", "1004", 5800000, "Index")]
        [TestCase("0219", "1005", 4200000, "Index")]
        [TestCase("0319", "1006", 2000000, "Index")]
        // Thành công do phù hợp MaSinhVien, MaHKNH, SoTienConLai
        [TestCase("0111", "1003", 2000000, "Create")]   // Thất bại do MaHKNH không nằm trong select list
        [TestCase("0118", "999", 2000000, "Create")]    // Thất bại do MaSinhVien không nằm trong select list
        [TestCase("0118", "1002", 0, "Create")]         // Thất bại do SoTienConLai phải > 0
        [TestCase("0319", "1006", 2000000, "Create")]   // Thất bại do duplicate với trên
        public void LapBaoCaoNoTest_Success(string MaHKNH, string MaSinhVien, decimal SoTienConLai, string expected)
        {
            BAOCAO_SV_NOHPController bAOCAO_SV_NOHPController = new BAOCAO_SV_NOHPController();
            BAOCAO_SV_NOHP bAOCAO_SV_NOHP = new BAOCAO_SV_NOHP
            {
                MaHKNH = MaHKNH,
                MaSinhVien = MaSinhVien,
                SoTienConLai = SoTienConLai,
            };
            RedirectToRouteResult result = bAOCAO_SV_NOHPController.Create(bAOCAO_SV_NOHP) as RedirectToRouteResult;
            Assert.AreEqual(expected, result.RouteValues["action"].ToString());
        }

    }
}
