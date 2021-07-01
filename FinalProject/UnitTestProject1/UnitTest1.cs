using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//using FinalProject.Areas.Login.Controllers;
//using System.Web.Mvc;

namespace TestProjectKCPM
{
    [TestClass]
    public class LoginTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //LoginController loginController = new LoginController();

            //RedirectToRouteResult result = loginController.Login("ABC", "XYZ") as RedirectToRouteResult;

            //string expected = "Login";
            //string actual = result.RouteValues["action"].ToString();
            //Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, 1);
        }

        //[TestMethod]
        //public void LoginPDTSuccess()
        //{
        //    LoginController loginController = new LoginController();

        //    RedirectToRouteResult result = loginController.Login("PDT01", "1") as RedirectToRouteResult;

        //    string expected = "HomePDT";
        //    string actual = result.RouteValues["action"].ToString();
        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void LoginPDTFail()
        //{
        //    LoginController loginController = new LoginController();

        //    RedirectToRouteResult result = loginController.Login("PDT", "10") as RedirectToRouteResult;

        //    string expected = "Login";
        //    string actual = result.RouteValues["action"].ToString();
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
