using System.Collections.Generic;
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
        public void UserList()
        {
            // Arrange
            var controller = new UserController(new UserBLL(new DBUserStub()));
            var expectedResult = new List<VMUser>();
            var user = new VMUser()
            {
                Id = 1,
                Userlevel = 1,
                Email = "trude@oslomet.no",
                Firstname = "Trude",
                Surname = "Solberg",
                Password = "test",
                Address = "Frognerveien 24B",
                ZipCode = "9999",
                Area = "test",
            };
            expectedResult.Add(user);
            expectedResult.Add(user);
            expectedResult.Add(user);

            // Act
            var actionResult = (ViewResult)controller.UserList();
            var result = (List<VMUser>)actionResult.Model;

            // Assert
            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Id, result[i].Id);
                Assert.AreEqual(expectedResult[i].Email, result[i].Email);
                Assert.AreEqual(expectedResult[i].Firstname, result[i].Firstname);
                Assert.AreEqual(expectedResult[i].Surname, result[i].Surname);
                Assert.AreEqual(expectedResult[i].Password, result[i].Password);
                Assert.AreEqual(expectedResult[i].Address, result[i].Address);
                Assert.AreEqual(expectedResult[i].ZipCode, result[i].ZipCode);
                Assert.AreEqual(expectedResult[i].Area, result[i].Area);
            }
        }

        [TestMethod]
        public void UserDelete_Admin()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new UserController(new UserBLL(new DBUserStub()));
            SessionMock.InitializeController(controller);
            controller.Session["Userlevel"] = "1";
            var user = new VMUser()
            {
                Id = 1,
                Userlevel = 1,
                Email = "trude@oslomet.no",
                Firstname = "Trude",
                Surname = "Solberg",
                Password = "test",
                Address = "Frognerveien 24B",
                ZipCode = "9999",
                Area = "test",
            };

            // Act
            var result = (RedirectToRouteResult)controller.UserDelete(1);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "UserList");
        }

        [TestMethod]
        public void UserDelete_Not_Admin()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new UserController(new UserBLL(new DBUserStub()));
            SessionMock.InitializeController(controller);
            controller.Session["Userlevel"] = "0";
            controller.Session["AccessFailedAdmin"] = "true";

            // Act
            var result = (RedirectToRouteResult)controller.UserDelete(1);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "MovieList");
        }

        [TestMethod]
        public void UserDelete_Not_Logged_In()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new UserController(new UserBLL(new DBUserStub()));
            SessionMock.InitializeController(controller);
            controller.Session["AccessFailedLogin"] = "true";

            // Act
            var result = (RedirectToRouteResult)controller.UserDelete(1);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "UserLogin");
        }

        [TestMethod]
        public void UserDetailAdminView()
        {
            // Arrange
            var controller = new UserController(new UserBLL(new DBUserStub()));
            var expectedResult = new VMUser()
            {
                Id = 1,
                Userlevel = 0,
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
            Assert.AreEqual(expectedResult.Userlevel, result.Userlevel);
            Assert.AreEqual(expectedResult.Email, result.Email);
            Assert.AreEqual(expectedResult.Firstname, result.Firstname);
            Assert.AreEqual(expectedResult.Surname, result.Surname);
            Assert.AreEqual(expectedResult.Password, result.Password);
            Assert.AreEqual(expectedResult.Address, result.Address);
            Assert.AreEqual(expectedResult.ZipCode, result.ZipCode);
            Assert.AreEqual(expectedResult.Area, result.Area);
        }

        [TestMethod]
        public void UserEdit()
        {
            // Arrange
            var controller = new UserController(new UserBLL(new DBUserStub()));
            var expectedResult = new VMUser()
            {
                Id = 1,
                Userlevel = 0,
                Email = "trude@oslomet.no",
                Firstname = "Trude",
                Surname = "Solberg",
                Password = "test",
                Address = "Frognerveien 24B",
                ZipCode = "9999",
                Area = "test",
            };

            // Act
            var result = (ViewResult)controller.UserEdit(1);

            // Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void UserEdit_Post_Valid()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new UserController(new UserBLL(new DBUserStub()));
            SessionMock.InitializeController(controller);
            controller.Session["EditSuccess"] = "true";
            var user = new VMUser()
            {
                Id = 1,
                Userlevel = 0,
                Email = "trude@oslomet.no",
                Firstname = "Trude",
                Surname = "Solberg",
                Password = "test",
                Address = "Frognerveien 24B",
                ZipCode = "9999",
                Area = "test",
            };

            // Act
            var result = (RedirectToRouteResult)controller.UserEdit(1, user);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "UserList");
        }

        [TestMethod]
        public void UserEdit_Post_Not_OK()
        {
            // Arrange
            var controller = new UserController(new UserBLL(new DBUserStub()));
            var user = new VMUser();
            controller.ViewData.ModelState.AddModelError("Email", "Invalid Email Address");

            // Act
            var result = (ViewResult)controller.UserEdit(0, user);

            // Assert
            Assert.IsTrue(result.ViewData.ModelState.Count == 1);
            Assert.AreEqual(result.ViewName, "");
        }
    }

}
