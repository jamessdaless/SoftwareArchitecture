using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderService.Models
{
    public class CartItem
    {
        public virtual int productId { get; set; }
        public virtual int cartId { get; set; }
        public virtual int quantity { get; set; }
        public System.DateTime DateCreated { get; set; }
    }
}