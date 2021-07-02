using NUnit.Framework;
using FinalProject.Areas.PDT.Controllers;
using FinalProject.Models;
using System.Web.Mvc;
using System.Net;

namespace TestProjectKCPM.NhapDanhSachMonHoc
{
    [TestFixture]
    public class MonHocTest
    {
        // Create(MONHOC) Test
        [Test]
        [TestCase("IT81", "Giới thiệu ngành", "TH", 45, "Index")] // Thêm được do chưa có
        [TestCase("IT82", "Giới thiệu ngành", "TH", 45, "Index")] // Thêm được do chưa có
        [TestCase("IT01", "Giới thiệu ngành", "LT", 45, "Create")] // Lỗi do đã có
        [TestCase("IT831", "Giới thiệu ngành", "TH", 45, "Create")] // Lỗi do MaMonHoc char(5)
        [TestCase("IT8", "Giới thiệu ngành", "TH", 45, "Create")] // Lỗi do MaMonHoc char(3)
        [TestCase("", "Giới thiệu ngành", "TH", 45, "Create")] // Lỗi do MaMonHoc trống
        [TestCase("IT83", "", "TH", 45, "Create")]// Lỗi do tên môn học trống
        [TestCase("IT84", "Giới thiệu ngành", "AB", 45, "Create")] // Lỗi do MaLoaiMon không tồn tại
        [TestCase("IT85", "Giới thiệu ngành", "", 45, "Create")] // Lỗi do MaLoaiMon trống
        [TestCase("IT86", "Giới thiệu ngành", "TH", -4, "Create")] //  Lỗi do SoTiet âm
        [TestCase("IT87", "Giới thiệu ngành", "TH", 0, "Create")] //  Lỗi do SoTiet = 0
        public void CreateMonHocPostTest(string MaMonHoc,
            string TenMonHoc, string MaLoaiMon, int SoTiet, string expected)
        {
            MONHOC mONHOC = new MONHOC
            {
                MaMonHoc = MaMonHoc,
                TenMonHoc = TenMonHoc,
                MaLoaiMon = MaLoaiMon,
                SoTiet = SoTiet
            };
            MONHOCsController mONHOCsController = new MONHOCsController();
            RedirectToRouteResult result = mONHOCsController.Create(mONHOC) as RedirectToRouteResult;
            Assert.AreEqual(expected, result.RouteValues["action"].ToString());
        }

        [Test]
        [TestCase(1, "Sai"),]
        [TestCase(0, "Dung"),]
        [TestCase(-1, "Dung"),]
        public void CreateMonHocGetTest(int id, string expected)
        {
            MONHOCsController mONHOCsController = new MONHOCsController();
            var res = mONHOCsController.Create(id) as ViewResult;
            Assert.AreEqual(expected, res.ViewData["m"]);
            Assert.AreEqual(typeof(SelectList), res.ViewData["MaLoaiMon"]);
        }

        // Details(string) test
        [Test]
        [TestCase("IT01")] // Trả về được do có
        [TestCase("IT02")] // Trả về được do có
        public void DetailsMonHocTestSuccess(string id)
        {
            MONHOCsController mONHOCsController = new MONHOCsController();
            ViewResult result = mONHOCsController.Details(id) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }
        [Test]
        [TestCase("IT1")] // FAILED
        [TestCase("IT111")] // FAILED
        [TestCase("")] // FAILED
        public void DetailsMonHocTestFail(string id)
        {
            MONHOCsController mONHOCsController = new MONHOCsController();
            HttpStatusCodeResult result = mONHOCsController.Details(id) as HttpStatusCodeResult;
            Assert.AreEqual(((int)HttpStatusCode.NotFound), result.StatusCode);
        }
        [Test]
        [TestCase(null)] // FAILED
        public void DetailsMonHocTestNull(string id)
        {
            MONHOCsController mONHOCsController = new MONHOCsController();
            HttpStatusCodeResult result = mONHOCsController.Details(id) as HttpStatusCodeResult;
            Assert.AreEqual(((int)HttpStatusCode.BadRequest), result.StatusCode);
        }
        
        // Edit Test
        [Test]
        [TestCase("IT01")] // Trả về được do có
        [TestCase("IT02")] // Trả về được do có
        public void EditMonHocGetTestSuccess(string id)
        {
            MONHOCsController mONHOCsController = new MONHOCsController();
            ViewResult result = mONHOCsController.Edit(id) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }
        [Test]
        [TestCase("IT1")] // FAILED
        [TestCase("IT111")] // FAILED
        [TestCase("")] // FAILED
        public void EditMonHocTestFail(string id)
        {
            MONHOCsController mONHOCsController = new MONHOCsController();
            HttpStatusCodeResult result = mONHOCsController.Edit(id) as HttpStatusCodeResult;
            Assert.AreEqual(((int)HttpStatusCode.NotFound), result.StatusCode);
        }
        [Test]
        [TestCase(null)] // FAILED
        public void EditMonHocTestNull(string id)
        {
            MONHOCsController mONHOCsController = new MONHOCsController();
            HttpStatusCodeResult result = mONHOCsController.Details(id) as HttpStatusCodeResult;
            Assert.AreEqual(((int)HttpStatusCode.BadRequest), result.StatusCode);
        }

        [Test]
        [TestCase("IT81", "Đổi tên để edit", "TH", 45, "Index")] // Đổi được do đã có mã môn học
        [TestCase("IT82", "Đổi tên cho edit", "TH", 45, "Index")] // Đổi được do đã có mã môn học
        [TestCase("IT01", "Đổi tên cho edit", "LT", 45, "Index")] // Đổi được do đã có mã môn học
        [TestCase("IT831", "Giới thiệu ngành", "TH", 45, "Edit")] // Không đổi được do mã không có
        [TestCase("IT8", "Giới thiệu ngành", "TH", 45, "Edit")] // Không đổi được do mã không có
        [TestCase("", "Giới thiệu ngành", "TH", 45, "Edit")] // Không đổi được do mã không có
        [TestCase("IT83", "", "TH", 45, "Edit")]// Không đổi được do mã không có
        [TestCase("IT84", "Giới thiệu ngành", "AB", 45, "Edit")] // Không đổi được do mã không có
        [TestCase("IT85", "Giới thiệu ngành", "", 45, "Edit")] // Không đổi được do mã không có
        [TestCase("IT86", "Giới thiệu ngành", "TH", -4, "Edit")] //  Không đổi được do mã không có
        [TestCase("IT87", "Giới thiệu ngành", "TH", 0, "Edit")] //  Không đổi được do mã không có
        public void EditMonHocPostTest(string MaMonHoc,
            string TenMonHoc, string MaLoaiMon, int SoTiet, string expected)
        {
            MONHOCsController mONHOCsController = new MONHOCsController();
            MONHOC mONHOC = new MONHOC
            {
                MaMonHoc = MaMonHoc,
                TenMonHoc = TenMonHoc,
                MaLoaiMon = MaLoaiMon,
                SoTiet = SoTiet,
            };
            var result = mONHOCsController.Edit(mONHOC) as RedirectToRouteResult;
            Assert.AreEqual(expected, result.RouteValues["action"].ToString());
        }
    }
}
