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
            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(orderList[i].Id, result[i].Id);
                Assert.AreEqual(orderList[i].Date, result[i].Date);
                Assert.AreEqual(orderList[i].UserId, result[i].UserId);
            }
        }
    }
}
