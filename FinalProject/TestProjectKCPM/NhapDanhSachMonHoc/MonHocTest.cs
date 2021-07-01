using NUnit.Framework;
using FinalProject.Areas.PDT.Controllers;
using FinalProject.Models;
using System.Web.Mvc;


namespace TestProjectKCPM.NhapDanhSachMonHoc
{
    [TestFixture]
    public class MonHocTest
    {
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
        public void CreateMonHocTest(string MaMonHoc,
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
    }
}
