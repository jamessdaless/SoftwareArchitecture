using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAPI.Controllers;
using OrderDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderAPI.Controllers.Tests
{
    [TestClass()]
    public class OrdersControllerTests
    {
        OrdersController b = new OrdersController();

        [TestMethod()]
        public void GetOrdersTest()
        {
            IEnumerable<Dtos.Orders> a = b.GetOrders();
            Assert.IsInstanceOfType(a, typeof(IEnumerable<Dtos.Orders>));
        }

        [TestMethod()]
        public void GetOrderTest()
        {
            Order a = b.GetOrder(1);
            Assert.IsInstanceOfType(a, typeof(Order));
        }

        [TestMethod()]
        public void GetOrdersByCustomerIdTest()
        {
            IEnumerable<Dtos.Orders> a = b.GetOrdersByCustomerId(1);
            Assert.IsInstanceOfType(a, typeof(IEnumerable<Dtos.Orders>));
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            Order a = b.GetOrder(1);
            Assert.IsInstanceOfType(a, typeof(Order));
        }
    }
}