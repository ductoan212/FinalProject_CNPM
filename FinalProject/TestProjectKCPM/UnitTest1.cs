using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FinalProject.Areas.Login.Controllers;
using System.Web.Mvc;

namespace TestProjectKCPM
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LoginController loginController = new LoginController();

            ViewResult result = loginController.Login("ABC", "XYZ") as ViewResult;

            string expected = "Login";
            string actual = result.ViewName;
            Assert.AreEqual(expected, actual);
        }
    }
}
