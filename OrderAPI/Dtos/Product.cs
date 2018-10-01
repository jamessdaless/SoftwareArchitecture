using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderAPI.Dtos
{
    public class Product
    {
        public virtual int productId { get; set; }
        public virtual string name { get; set; }
        public virtual double price { get; set; }
        public virtual double originalPrice { get; set; }
        public virtual string description { get; set; }
        public virtual int stockLevel { get; set; }
        public virtual bool Active { get; set; }
    }
}