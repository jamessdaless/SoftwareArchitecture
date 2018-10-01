namespace OrderAPI.Dtos
{
    public class Orders
    {
        public virtual int userId { get; set; }
        public virtual int orderId { get; set; }
        public virtual int productId { get; set; }
        public virtual string name {get; set;}
        public virtual double price { get; set; }
        public virtual int quantity { get; set; }
        public virtual bool Active { get; set; }
    }
}