using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Controllers.Tests
{
    [TestClass()]
    public class OrdersControllerTests
    {
        [TestMethod()]
        public void OrdersControllerTest()
        {
            //Arrange 
            //var controller = new OrdersController();
           // ViewResult result = controller.Index() as ViewResult();

            //Act

            //Assert

        }

        [TestMethod()]
        public void IndexTest()
        {
            var controller = new OrdersController();

        }

        [TestMethod()]
        public void getOrdersbyCustomerIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DetailsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            Assert.Fail();
        }
    }
}