using OrderDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRepository
{
    public interface IOrderRepository : IDisposable
    {
        IEnumerable<Order> getOrders();
        IEnumerable<Order> getOrdersById(int? orderId);
        IEnumerable<Customer> getCustomerById(int? userId);
        IEnumerable<Order> getOrdersByCustomerId(int? userId);
        IEnumerable<Product> GetProduct();
        IEnumerable<Product> getProductsById(int? productId);
        Order GetOrder(int id);
        void InsertCustomer(Customer customer);
        void DeleteCustomer(int? userId);
        void InsertOrder(Order order);
        void DeleteOrder(int? orderId);
        void UpdateOrder(Order order);
        void Save();
       

    }
}
