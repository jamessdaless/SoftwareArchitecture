using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrderAPI.Models;
using OrderDatabase.Model;
using OrderRepository;

namespace OrderAPI.Controllers
{
    public class OrdersController : ApiController
    {


        private IOrderRepository repository;

        public OrdersController()
        {
            this.repository = new OrderRepo(new OrderDb());
        }

       


        // example ---- http://localhost:52389/api/getorders?orderid=4
        [HttpGet]
        [Route("api/getOrders")]
        public IEnumerable<Dtos.Orders> GetOrders()
        {
            var orders = repository.getOrders().Select(o => new Dtos.Orders()
            {
                orderId = o.orderId,
                name = o.name,
                productId = o.productId,
                price = o.price,
                quantity = o.quantity
            });

            return orders;
        }

        [HttpGet]
        [Route("api/getOrder")]
        public Order GetOrder(int id)
        {
            Order order = repository.GetOrder(id);
            return order;
        }

        //example -- http://localhost:52389/api/getcustomerorder?userid=1
        [HttpGet]
        [Route("api/getCustomerOrder")]
        public IEnumerable<Dtos.Orders> GetOrdersByCustomerId(int userId)
        {
            var orders = repository.getOrdersByCustomerId(userId).Select(o => new Dtos.Orders()
            {
                orderId = o.orderId,
                name = o.name,
                userId = o.userId,
                price = o.price,
                quantity = o.quantity
            });

            return orders;
        }

        [HttpDelete]
        [Route("api/deleteOrder/{orderId}")]
        public IHttpActionResult DeleteOrder(int orderId)
        { 
            repository.DeleteOrder(orderId);
            repository.Save();
            return Ok();
        }

        
    }
}