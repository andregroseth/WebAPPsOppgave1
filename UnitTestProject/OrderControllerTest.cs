using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebAppsProsjekt1.BLL;
using WebAppsProsjekt1.Controllers;
using WebAppsProsjekt1.DAL;
using WebAppsProsjekt1.Model;

namespace UnitTestProject
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void OrderListAdminView()
        {
            // Arrange
            var orderController = new OrderController(new OrderBLL(new DBOrderStub()));
            var orderList = new List<VMOrder>();
            var order = new VMOrder()
            {
                Id = 1,
                Date = "12/10/2018",
                UserId = 1,
            };
            orderList.Add(order);
            orderList.Add(order);
            orderList.Add(order);

            // Act
            var actionResult = (ViewResult)orderController.OrderListAdminView(1);
            var result = (List<VMOrder>)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(orderList[i].Id, result[i].Id);
                Assert.AreEqual(orderList[i].Date, result[i].Date);
                Assert.AreEqual(orderList[i].UserId, result[i].UserId);
            }
        }

        [TestMethod]
        public void OrderDetailAdminView()
        {
            // Arrange
            var orderController = new OrderController(new OrderBLL(new DBOrderStub()));
            var orderlineList = new List<VMOrderline>();
            var orderline = new VMOrderline()
            {
                UserId = 1,
                Id = 1,
                MovieId = 1,
                Title = "Test Title",
                Category = "Test",
                Cost = 123,
                ImagePath = "Test"
            };
            orderlineList.Add(orderline);
            orderlineList.Add(orderline);
            orderlineList.Add(orderline);

            // Act
            var actionResult = (ViewResult)orderController.OrderDetailAdminView(1, 1);
            var result = (List<VMOrderline>)actionResult.Model;

            // Assert
            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(orderlineList[i].UserId, result[i].UserId);
                Assert.AreEqual(orderlineList[i].Id, result[i].Id);
                Assert.AreEqual(orderlineList[i].MovieId, result[i].MovieId);
                Assert.AreEqual(orderlineList[i].Title, result[i].Title);
                Assert.AreEqual(orderlineList[i].Category, result[i].Category);
                Assert.AreEqual(orderlineList[i].Cost, result[i].Cost);
                Assert.AreEqual(orderlineList[i].ImagePath, result[i].ImagePath);
            }
        }
    }
}
