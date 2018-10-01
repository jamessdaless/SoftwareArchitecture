using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderService.Models
{
    public class ProductVm
    {
        [Required]
        [Display(Name = "Product ID")]
        public virtual int productId { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public virtual string name { get; set; }
        [Required]
        [Display(Name = "Price")]
        public virtual double price { get; set; }
        [Required]
        [Display(Name = "Original Price")]
        public virtual double originalPrice { get; set; }
        [Required]
        [Display(Name = "Description")]
        public virtual string description { get; set; }
        [Required]
        [Display(Name = "Stock Level")]
        public virtual int stockLevel { get; set; }
        //[Required]
        //[Display(Name = "Active")]
        //public virtual bool Active { get; set; }

        public static IEnumerable<Models.ProductVm> buildList(IEnumerable<OrderDatabase.Model.Product> product)
        {
            var products = product.Select(p => new ProductVm()
            {
                productId = p.productId,
                name = p.name,
                price = p.price,
                originalPrice = p.originalPrice,
                description = p.description,
                stockLevel = p.stockLevel
               
            });

            return products;
        }
    }
}