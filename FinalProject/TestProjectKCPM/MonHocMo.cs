using NUnit.Framework;
using System.Web.Mvc;
using FinalProject.Areas.PDT.Controllers;

namespace TestProjectKCPM
{
    [TestFixture]
    public class MonHocMo
    {
        [Test]
        [TestCase("0121","IT06,IT07", "Index")]
        public void testThemMonHocMo(string maHKNH, string ids, string expected)
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
