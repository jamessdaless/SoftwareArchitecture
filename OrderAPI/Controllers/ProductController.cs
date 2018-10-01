using OrderDatabase.Model;
using OrderRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderAPI.Controllers
{
    public class ProductController : ApiController
    {
        private OrderDb db = new OrderDb();

        private IOrderRepository repository;

        public ProductController()
        {
            this.repository = new OrderRepo(new OrderDb());
        }

        // example ---- http://localhost:52389/api/getproducts?productid=1
        [HttpGet]
        [Route("api/getProducts")]
        public IEnumerable<Dtos.Product> GetProducts(int productId)
        {
            var products = repository.getProductsById(productId).Select(o => new Dtos.Product()
            {
                productId = o.productId,
                name = o.name,
                description = o.description,
                stockLevel = o.stockLevel,
                price = o.price

            });

            return products;
        }
    }
}
