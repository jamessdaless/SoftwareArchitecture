using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderDatabase.Model
{
    public class Order
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int orderId { get; set; }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int userId { get; set; }
        public virtual int productId { get; set; }
        public virtual string name { get; set; }
        public virtual double price { get; set; }
        public virtual int quantity { get; set; }
        public virtual bool Active { get; set; }
    }
}
