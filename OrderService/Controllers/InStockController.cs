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

namespace OrderService.Controllers
{
    public class InStockController : Controller
    {
        private OrderDb db = new OrderDb();
        private IOrderRepository repository;

        //test product id
        private int productId = 1;

        public InStockController()
        {
            this.repository = new OrderRepo(new OrderDb());
        }

        // GET: InStock
        public ActionResult Index()
        {
            return View(db.Products.ToList());

            IEnumerable<OrderDatabase.Model.Product> o = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:52389/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpResponseMessage response = client.GetAsync("/api/getproduct?productid=" + productId).Result;
            if (response.IsSuccessStatusCode)
            {
                o = response.Content.ReadAsAsync<IEnumerable<OrderDatabase.Model.Product>>().Result;


            }
            return View(o);
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
