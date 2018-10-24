using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using WebAppsProsjekt1.BLL;
using WebAppsProsjekt1.Controllers;
using WebAppsProsjekt1.DAL;
using WebAppsProsjekt1.Model;

namespace UnitTestProject
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void UserDetailAdminView_Session_True()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new UserController(new UserBLL(new DBUserStub()));
            SessionMock.InitializeController(controller);
            controller.Session["IfAdmin"] = "true";
            var expectedResult = new VMUser()
            {
                Id = 1,
                Userlvl = 0,
                Email = "trude@oslomet.no",
                Firstname = "Trude",
                Surname = "Solberg",
                Password = "test",
                Address = "Frognerveien 24B",
                ZipCode = "9999",
                Area = "test",
            };

            // Act
            var actionResult = (ViewResult)controller.UserDetailAdminView(1);
            var result = (VMUser)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(expectedResult.Userlvl, result.Userlvl);
            Assert.AreEqual(expectedResult.Email, result.Email);
            Assert.AreEqual(expectedResult.Firstname, result.Firstname);
            Assert.AreEqual(expectedResult.Surname, result.Surname);
            Assert.AreEqual(expectedResult.Password, result.Password);
            Assert.AreEqual(expectedResult.Address, result.Address);
            Assert.AreEqual(expectedResult.ZipCode, result.ZipCode);
            Assert.AreEqual(expectedResult.Area, result.Area);
        }

        [TestMethod]
        public void UserDetailAdminView_Session_Null()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new UserController(new UserBLL(new DBUserStub()));
            SessionMock.InitializeController(controller);
            controller.Session["IfAdmin"] = null;
            var expectedResult = new VMUser()
            {
                Id = 1,
                Userlvl = 0,
                Email = "trude@oslomet.no",
                Firstname = "Trude",
                Surname = "Solberg",
                Password = "test",
                Address = "Frognerveien 24B",
                ZipCode = "9999",
                Area = "test",
            };

            // Act
            var result = (RedirectToRouteResult)controller.UserDetailAdminView(1);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "MovieList");
        }

        [TestMethod]
        public void UserDetailAdminView_Not_Logged_In()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new UserController(new UserBLL(new DBUserStub()));
            SessionMock.InitializeController(controller);
            controller.Session["IfAdmin"] = null;
            controller.Session["AccessFailedLogin"] = true;
            var expectedResult = new VMUser()
            {
                Id = 1,
                Userlvl = 0,
                Email = "trude@oslomet.no",
                Firstname = "Trude",
                Surname = "Solberg",
                Password = "test",
                Address = "Frognerveien 24B",
                ZipCode = "9999",
                Area = "test",
            };

            // Act
            var result = (RedirectToRouteResult)controller.UserDetailAdminView(1);

            // Assert
            Assert.AreEqual(result.RouteName, "");
        }

        [TestMethod]
        public void UserEdit()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new UserController(new UserBLL(new DBUserStub()));
            SessionMock.InitializeController(controller);
            controller.Session["Login"] = null;
            var expectedResult = new VMUser()
            {
                Id = 1,
                Userlvl = 0,
                Email = "trude@oslomet.no",
                Firstname = "Trude",
                Surname = "Solberg",
                Password = "test",
                Address = "Frognerveien 24B",
                ZipCode = "9999",
                Area = "test",
            };

            // Act
            var result = (RedirectToRouteResult)controller.UserEdit(1);

            // Assert
            Assert.AreEqual(result.RouteName, "");
        }
    }

}
