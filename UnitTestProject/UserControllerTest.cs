﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void UserDetailAdminView()
        {
            // Arrange
            var controller = new UserController(new UserBLL(new DBUserStub()));
            //var testMail = new Mail
            //{
            //    ZipCode = "9999",
            //    Area = "test"
            //};
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
    }
}
