using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using FinalProject.Models;
using FinalProject.Controllers;
using System.Web.Mvc;
using FinalProject.Areas.PDT.Controllers;
using Assert = NUnit.Framework.Assert;

namespace TestProjectKCPM.MonHocMo
{
    [TestFixture]
    
    public class HKNHoc
    {
        [TestMethod]
        public void ViewHKNH()
        {
            HKNHsController hKNHsController = new HKNHsController();
            ViewResult result = hKNHsController.Index() as ViewResult;
            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateViewHKNH()
        {
            HKNHsController hKNH = new HKNHsController();

            ViewResult result = hKNH.Create() as ViewResult;
            Assert.IsNotNull(result);
            string expected = "";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("0223","2","2023","2024","01/09/2024", "ListHK")] // Thêm được
        [TestCase("0121", "1", "2021", "2022", "10/12/2021", "Create")] //Không được vì đã tồn tại
        [TestCase("0322", "-1", "2022", "2023", "12/12/2021", "Create")] //Không được vì HocKy < 1
        [TestCase("0321", "3", "2021", "2022", "32/24/2022", "Create")] // Không được vì sai định dạng ngày
        [TestCase("0123", "2", "2023", "2025", "12/12/2022", "Create")] // Không được vì Nam2 - Nam1 khác 1
        [TestCase("0323", "3", "2023", "2024", "12/12/2022", "Create")] // Không được vì hạn đóng sai với thời gian học
        public void CreatePostHKNH(string MaHKNH, string HocKy, int Nam1, int Nam2, DateTime HanDongHocPhi, string expected)
        {
            HKNH hKNH = new HKNH
            {
                MaHKNH = MaHKNH,
                HocKy = HocKy,
                Nam1 = Nam1,
                Nam2 = Nam2,
                HanDongHocPhi = Convert.ToDateTime(HanDongHocPhi)
            };
            HKNHsController hKNHsController = new HKNHsController();
            RedirectToRouteResult result = hKNHsController.Create(hKNH) as RedirectToRouteResult;
            Assert.AreEqual(expected, result.RouteValues["action"].ToString());
        }
    }
}
