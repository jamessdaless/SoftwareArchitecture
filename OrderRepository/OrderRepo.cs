using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDatabase.Model;
using System.Data.Entity;

namespace OrderRepository
{
    public class OrderRepo : IOrderRepository, IDisposable
    {
        private OrderDb context;

        public OrderRepo(OrderDb context)
        {
            this.context = context;
        }


        //get the current orders in the database
        public IEnumerable<Order> getOrders()
        {
            return context.Orders.ToList();
        }


        //delete a order
        public void DeleteOrder(int? orderId)
        {
            Order o = context.Orders.Find(1, 1);
            o.Active = false;

        }

        private bool d = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.d)
            {
                if (disposing)
                {
                    context.Dispose();
                }

            }
            this.d = true;

        }

        //get the orders by the order id
        public IEnumerable<Order> getOrdersById(int? orderId)
        {
            var orders = context.Orders.Where(o => o.Active == true && o.orderId == orderId);
            return orders;
        }

        //get the customers by customer id
        public IEnumerable<Customer> getCustomerById(int? userId)
        {
            var customers = context.Customers.Where(c => c.Active == true && c.userId == userId);
            return customers;
        }

        //add new customer
        public void InsertCustomer(Customer customer)
        {
            context.Customers.Add(customer);
        }

        //delete customer
        public void DeleteCustomer(int? userId)
        {
            Customer c = context.Customers.Find(userId);
            c.Active = false;
        }

        //insert customer
        public void InsertOrder(Order order)
        {
            context.Orders.Add(order);
        }

        //update order
        public void UpdateOrder(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        //create a list of orders made by a customer
        public IEnumerable<Order> getOrdersByCustomerId(int? userId)
        {
            var orders = context.Orders.Where(o => o.Active == true && o.userId == userId);
            return orders;
        }



        public IEnumerable<Product> GetProduct()
        {
            throw new NotImplementedException();
        }
        
        //get a list of products by id
        public IEnumerable<Product> getProductsById(int? productId)
        {
            return context.Products.ToList();
        }

        //get a certain order (order number 1 with product id of 1)
        public Order GetOrder(int id)
        {
            return context.Orders.Find(1, 1);
        }

    }
}

