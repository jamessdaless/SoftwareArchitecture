using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderAPI.Models
{
    public class Orders
    {
        public virtual int orderId { get; set; }
        public virtual int productId { get; set; }
        public virtual double price { get; set; }
        public virtual int quantity { get; set; }
        public virtual bool active { get; set; }
    }
}