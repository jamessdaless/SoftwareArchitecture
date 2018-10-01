using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderService.Models
{
    public class CustomerVM
    {
        [Required]
        public virtual int userId { get; set; }
        [Required]
        public virtual int orderId { get; set; }
        [Required]
        public virtual string cardNumber { get; set; }
        public virtual bool Active { get; set; }

        public static IEnumerable<Models.CustomerVM> buildList(IEnumerable<OrderDatabase.Model.Customer> Customer)
        {
            var customer = Customer.Select(c => new CustomerVM()
            {
                userId = c.userId,
                orderId = c.orderId,
                cardNumber = c.cardNumber
            });

            return customer;
        }
    }
}