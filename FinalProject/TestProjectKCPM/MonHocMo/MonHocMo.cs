using NUnit.Framework;
using System.Web.Mvc;
using FinalProject.Areas.PDT.Controllers;
using Assert = NUnit.Framework.Assert;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProjectKCPM.MonHocMo
{
    [TestFixture]
    public class MonHocMo
    {
        [TestMethod]
        public void ViewMonHocMo()
        {
            DS_MONHOC_MOController dS_MONHOC_MOController = new DS_MONHOC_MOController();
            ViewResult result = dS_MONHOC_MOController.Index("0121") as ViewResult;
            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateViewMonHocMo()
        {
            DS_MONHOC_MOController dS_MONHOC_MOController = new DS_MONHOC_MOController();
            ViewResult result = dS_MONHOC_MOController.Create("0121") as ViewResult;

            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase("0121", "IT06,IT07", "Index")] // Thành công
        [TestCase("121", "IT06,IT07", "Create")] // Mã HKNH không đúng định dạng
        [TestCase("0425", "IT06,IT07", "Create")] // Mã HKNH không tồn tại
        [TestCase("0121", "IT06,IL07", "Create")] // Mã môn học không tồn tại
        public void CreatePostMonHocMo(string maHKNH, string ids, string expected)
        {
            var form = new FormCollection();
            form["ID"] = ids;
            DS_MONHOC_MOController dS_MONHOC_MOController = new DS_MONHOC_MOController();
            dS_MONHOC_MOController.hk = maHKNH;
            //dS_MONHOC_MOController.List();
            RedirectToRouteResult result = dS_MONHOC_MOController.List(form) as RedirectToRouteResult;
            Assert.AreEqual(expected, result.RouteValues["action"].ToString());
            
        }
    }
}
