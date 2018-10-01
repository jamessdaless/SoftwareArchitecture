using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderDatabase.Model;
using OrderRepository;
using System.Net.Http;
using OrderService.Models;

namespace OrderService.Controllers
{
    public class OrdersController : Controller
    {
        //test value
        private int userId = 1;
        private int orderId = 1;
        private OrderDb db = new OrderDb();
        HttpClient client = new HttpClient();

        private IOrderRepository repository;

        public OrdersController()
        {
            this.repository = new OrderRepo(new OrderDb());
        }
       
        // GET: Orders
        public ActionResult Index()
        {
            IEnumerable<OrderVM> o = null;

            client.BaseAddress = new System.Uri("http://localhost:52389/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpResponseMessage response = client.GetAsync("/api/getorders").Result;
            if (response.IsSuccessStatusCode)
            {
                o = response.Content.ReadAsAsync<IEnumerable<OrderVM>>().Result;

            }
            return View(o);

        }

        
        [HttpGet, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new System.Uri("http://localhost:52389/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpResponseMessage response = client.DeleteAsync("api/deleteorder/" + id).Result;
            return RedirectToAction("Index");
        }
      
        public ActionResult Delete(int id)
        {
            Order order = null;
            client.BaseAddress = new System.Uri("http://localhost:52389/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpResponseMessage response = client.GetAsync("api/getorder?id=" + id).Result;
            order = response.Content.ReadAsAsync<Order>().Result;

            var vm = Models.OrderVM.GetOrder(order);
            return View(vm);

        }

        public ActionResult Details(int? id)
        {
            IEnumerable<OrderVM> o = null;
            client.BaseAddress = new System.Uri("http://localhost:52389/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpResponseMessage response = client.GetAsync("api/getorders?orderid=" + orderId).Result;
            if (response.IsSuccessStatusCode)
            {
                o = response.Content.ReadAsAsync<IEnumerable<OrderVM>>().Result;

            }
            return View(o);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderId,name,productId,price,quantity,Active")] Order order)
        {
            if (ModelState.IsValid)
            {
                repository.InsertOrder(order);
                repository.Save();
                return RedirectToAction("Index");
            }

            //insert a if statement for price over £50 to add an invoice


            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<Order> order = repository.getOrdersById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderId,name,productId,price,quantity,Active")] Order order)
        {
            if (ModelState.IsValid)
            {
              
                repository.UpdateOrder(order);
                repository.Save();

                return RedirectToAction("Index");
            }
            return View(order);
        }

        

    

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
