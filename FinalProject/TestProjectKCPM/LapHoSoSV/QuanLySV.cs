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
        //private CNPMEntities db = new CNPMEntities();

        [Test]
        [TestCase()]
        public void ViewDSSV()
        {
            SINHVIENsController svController = new SINHVIENsController();

            ViewResult result = svController.Index() as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("1001", true)]
        [TestCase("9999", false)]
        [TestCase("001", false)]
        [TestCase("000001", false)]
        public void DetailSV(string MaSinhVien, bool isNotNull)
        {
            SINHVIENsController svController = new SINHVIENsController();

            ViewResult result = svController.Details(MaSinhVien) as ViewResult;

            if(isNotNull==true)
            {
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Model);
            }
            else
            {
                Assert.IsNull(result);
            }
        }

        [Test]
        [TestCase()]
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
        [TestCase("1010", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "DT02", "CNTT", "Index")]
        [TestCase("10", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "DT02", "CNTT", "Create")]
        [TestCase("11110", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "DT02", "CNTT", "Create")]
        [TestCase("1010", "Nguyen Van Test Van Test Van Test Van Test Van Test Van Test", "Nam", "01/01/2000", "3903", "DT02", "CNTT", "Create")]
        [TestCase("1010", "Nguyen Van Test", "Abc", "01/01/2000", "3903", "DT02", "CNTT", "Create")]
        [TestCase("1010", "Nguyen Van Test", "Nam", "01/01/2000", "3999", "DT02", "CNTT", "Create")]
        [TestCase("1010", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "DT00", "CNTT", "Create")]
        [TestCase("1010", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "DT02", "ABCD", "Create")]
        public void CreatePostSV(
            string MaSinhVien, string HoTen, 
            string GioiTinh, string NgaySinh,
            string MaHuyen, string MaDoiTuong, 
            string MaNganh, string expected)
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
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("1001", true)]
        [TestCase("001", false)]
        [TestCase("10001", false)]
        public void EditViewSV(string MaSinhVien, bool isSuccess)
        {
            SINHVIENsController svController = new SINHVIENsController();

            ViewResult result = svController.Edit(MaSinhVien) as ViewResult;

            if(isSuccess==true)
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
        [TestCase("1003", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "DT02", "CNTT", "Index", true)]
        [TestCase("03", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "DT02", "CNTT", "Edit", false)]
        [TestCase("", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "DT02", "CNTT", "Edit", false)]
        [TestCase("11003", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "DT02", "CNTT", "Index", false)]
        [TestCase("1003", "Nguyen Van Test Van Test Van Test Van Test Van Test Van Test Van Test", "Nam", "01/01/2000", "3903", "DT02", "CNTT", "Edit", true)]
        [TestCase("1003", "", "Nam", "01/01/2000", "3903", "DT02", "CNTT", "Edit", true)]
        [TestCase("1003", "Nguyen Van Test", "Van", "01/01/2000", "3903", "DT02", "CNTT", "Edit", true)]
        [TestCase("1003", "Nguyen Van Test", "", "01/01/2000", "3903", "DT02", "CNTT", "Edit", true)]
        [TestCase("1003", "Nguyen Van Test", "Nam", "01/01/2000", "3999", "DT02", "CNTT", "Edit", true)]
        [TestCase("1003", "Nguyen Van Test", "Nam", "01/01/2000", "", "DT02", "CNTT", "Edit", true)]
        [TestCase("1003", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "DT99", "CNTT", "Edit", true)]
        [TestCase("1003", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "", "CNTT", "Edit", true)]
        [TestCase("1003", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "DT02", "ABCD", "Edit", true)]
        [TestCase("1003", "Nguyen Van Test", "Nam", "01/01/2000", "3903", "DT02", "", "Edit", true)]
        public void EditPostSV(string MaSinhVien, 
            string HoTenNew, string GioiTinhNew, string NgaySinhNew,
            string MaHuyenNew, string MaDoiTuongNew, string MaNganhNew,
            string expected, bool isFoundSV)
        {
            SINHVIENsController svController = new SINHVIENsController();

            SINHVIEN sv = svController.GetSINHVIEN(MaSinhVien);
            if(isFoundSV)
            {
                Assert.IsNotNull(sv);
            }
            else
            {
                Assert.IsNull(sv);
                return;
            }
            sv.HoTen = HoTenNew;
            sv.GioiTinh = GioiTinhNew;
            sv.NgaySinh= Convert.ToDateTime(NgaySinhNew);
            sv.MaHuyen = MaHuyenNew;
            sv.MaDoiTuong = MaDoiTuongNew;
            sv.MaNganh = MaNganhNew;
            RedirectToRouteResult result = svController.Edit(sv) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            string actual = result.RouteValues["action"].ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
