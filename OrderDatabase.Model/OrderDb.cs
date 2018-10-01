using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OrderDatabase.Model
{
    class CustomerEntityTypeConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerEntityTypeConfiguration()
        {
            Property(c => c.userId).IsRequired();
            Property(c => c.orderId).IsRequired();
            Property(c => c.cardNumber).IsRequired();
        }
    }

    class OrderEntityTypeConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderEntityTypeConfiguration()
        {
            Property(o => o.userId).IsRequired();
            Property(o => o.orderId).IsRequired();
            Property(o => o.name).IsRequired();
            Property(o => o.productId).IsRequired();
            Property(o => o.price).IsRequired();
            Property(o => o.quantity).IsRequired();
           
        }
    }

    class ProductEntityTypeConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductEntityTypeConfiguration()
        {
            Property(p => p.productId).IsRequired();
            Property(p => p.name).IsRequired();
            Property(p => p.price).IsRequired();
            Property(p => p.originalPrice).IsRequired();
            Property(p => p.description).IsRequired();
            Property(p => p.stockLevel).IsRequired();

        }
    }



    public class OrderDb : DbContext, IDisposable
    {
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public OrderDb()
            : base("name=OrderService.OrderDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        static OrderDb()
        {
            System.Data.Entity.Database.SetInitializer(new DbInitializer());
        }

        class DbInitializer : CreateDatabaseIfNotExists<OrderDb>
        {
            protected override void Seed(OrderDb context)
            {
                //mock data for customers
                var customers = new List<Customer>()
                {
                    new Customer { userId = 1, orderId = 1, cardNumber = "1234321275865329", Active = true},
                    new Customer { userId = 2, orderId = 2, cardNumber = "1237263849573967", Active = true},
                    new Customer { userId = 3, orderId = 3, cardNumber = "1234567853557997", Active = true},
                    new Customer { userId = 4, orderId = 4, cardNumber = "1234383746215329", Active = true}
                };
                customers.ForEach(c => context.Customers.Add(c));

                //mock data for the orders
                var orders = new List<Order>()
                {
                    new Order { orderId = 1, name = "sponge", userId = 1,productId = 1, quantity = 1, price = 29.99, Active = true},
                    new Order { orderId = 2, name = "cat", userId = 2, productId = 2, quantity = 1, price = 339.99, Active = true},
                    new Order { orderId = 3, name = "dog", userId = 1, productId = 3, quantity = 1, price = 29.99, Active = true},
                    new Order { orderId = 4, name = "hat", userId = 3, productId = 4, quantity = 1, price = 229.99, Active = true}

                };
                orders.ForEach(o => context.Orders.Add(o));

                //mock data for the products
                var products = new List<Product>()
                {
                    new Product { productId = 1, name = "sponge", description = "does the job", price = 29.99, originalPrice = 20.99, stockLevel = 5, Active = true },
                    new Product { productId = 2, name = "hat", description = "keeps me head dry", price = 229.99, originalPrice = 200.99, stockLevel = 5, Active = true },
                    new Product { productId = 3, name = "cat", description = "talks the talk", price = 339.99, originalPrice = 200.99, stockLevel = 5, Active = true }

                };
                products.ForEach(p => context.Products.Add(p));
            

                context.SaveChanges();
                base.Seed(context);
            }


        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new OrderEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new CustomerEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ProductEntityTypeConfiguration());

            Database.SetInitializer<OrderDb>(new DbInitializer());
            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
