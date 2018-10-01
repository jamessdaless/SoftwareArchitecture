using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderDatabase.Model;
using System.Net.Http;
using OrderRepository;
using OrderService.Models;

namespace OrderService.Controllers
{
  

    public class OrderHistoryController : Controller
    {

        //test value
        private int userId = 1;
        
        private OrderDb db = new OrderDb();

        private IOrderRepository repository;

        public OrderHistoryController()
        {
            this.repository = new OrderRepo(new OrderDb());
        }

        

        // GET: OrderHistory
        public ActionResult Index()
        {
            //shows the order history for user 1

            IEnumerable<OrderDatabase.Model.Order> o = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:52389/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpResponseMessage response = client.GetAsync("/api/getcustomerorder?userid=" + userId).Result;
            if (response.IsSuccessStatusCode)
            {
                o = response.Content.ReadAsAsync<IEnumerable<OrderDatabase.Model.Order>>().Result;

            }
            return View(o);
        }

        // GET: OrderHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
