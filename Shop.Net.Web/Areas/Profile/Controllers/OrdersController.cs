namespace Shop.Net.Web.Areas.Profile.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using Shop.Net.Data;
    using Shop.Net.Model.Order;

    public class OrdersController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Profile/Orders
        public ActionResult Index()
        {
            return this.View(this.db.Orders.ToList());
        }

        // GET: Profile/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = this.db.Orders.Find(id);
            if (order == null)
            {
                return this.HttpNotFound();
            }

            return View(order);
        }

        // GET: Profile/Orders/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Profile/Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderStatus,CreatedOnUtc,UpdatedOnUtc")] Order order)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Orders.Add(order);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Profile/Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = this.db.Orders.Find(id);
            if (order == null)
            {
                return this.HttpNotFound();
            }

            return View(order);
        }

        // POST: Profile/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderStatus,CreatedOnUtc,UpdatedOnUtc")] Order order)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Entry(order).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Profile/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = this.db.Orders.Find(id);
            if (order == null)
            {
                return this.HttpNotFound();
            }

            return View(order);
        }

        // POST: Profile/Orders/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var order = this.db.Orders.Find(id);
            this.db.Orders.Remove(order);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}