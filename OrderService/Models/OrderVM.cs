using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderService.Models
{
    public class OrderVM
    {
        [Required]
        [Display(Name = "Customer ID")]
        public virtual int userId { get; set; }
        [Required]
        [Display(Name = "Order ID")]
        public virtual int orderId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public virtual string name { get; set; }
        [Required]
        [Display(Name = "Product ID")]
        public virtual int productId { get; set; }
        [Required]
        [Display(Name = "Cost")]
        public virtual double price { get; set; }
        [Required]
        [Display(Name = "Order Quantity")]
        public virtual int quantity { get; set; }



        public virtual bool Active { get; set; }

        public static IEnumerable<Models.OrderVM> buildList(IEnumerable<OrderDatabase.Model.Order> Order)
        {
            var order = Order.Select(o => new OrderVM()
            {
                userId = o.userId,
                orderId = o.orderId,
                name = o.name,
                price = o.price,
                quantity = o.quantity
            });

            return order;
        }
        public static OrderVM GetOrder(OrderDatabase.Model.Order o)
        {
            var order = new OrderVM()
            {
                userId = o.userId,
                orderId = o.orderId,
                name = o.name,
                price = o.price,
                quantity = o.quantity
            };

            return order;
        }
    }
}