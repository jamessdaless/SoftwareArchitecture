using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        ProductController b = new ProductController();


        [TestMethod()]
        public void GetProductsTest()
        {
            IEnumerable<Dtos.Product> a = b.GetProducts(1);
            Assert.IsInstanceOfType(a, typeof(IEnumerable<Dtos.Product>));
        }
    }
}