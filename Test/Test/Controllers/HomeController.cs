using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Test.Models; 

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Home/Index
        public ActionResult Index()
        {
            var salesOrders = db.SalesOrders.ToList(); // Mengambil semua sales order dari database
            return View(salesOrders); // Mengirimkan daftar sales order ke view
        }

        // GET: Home/AddItemOrder
        public ActionResult AddItemOrder()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "ComCustomerId", "CustomerName"); // Dropdown untuk customer
            return View(); // Tampilkan form untuk menambahkan sales order
        }

        // POST: Home/AddItemOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItemOrder(SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                db.SalesOrders.Add(salesOrder); // Tambahkan sales order baru ke database
                db.SaveChanges(); // Simpan perubahan
                return RedirectToAction("Index"); // Kembali ke daftar sales order
            }

            // Jika model tidak valid, kembalikan ke form dengan dropdown customer
            ViewBag.CustomerId = new SelectList(db.Customers, "ComCustomerId", "CustomerName", salesOrder.COM_CUSTOMER_ID);
            return View(salesOrder);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SalesOrder salesOrder = db.SalesOrders.Find(id); // Mencari sales order berdasarkan ID
            if (salesOrder == null)
            {
                return HttpNotFound();
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "ComCustomerId", "CustomerName", salesOrder.COM_CUSTOMER_ID); // Dropdown untuk customer
            return View(salesOrder); // Tampilkan form untuk mengedit sales order
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesOrder).State = EntityState.Modified; // Ubah status sebagai Modified
                db.SaveChanges(); // Simpan perubahan
                return RedirectToAction("Index"); // Kembali ke daftar sales order
            }

            // Jika model tidak valid, kembalikan ke form dengan dropdown customer
            ViewBag.CustomerId = new SelectList(db.Customers, "ComCustomerId", "CustomerName", salesOrder.COM_CUSTOMER_ID);
            return View(salesOrder);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SalesOrder salesOrder = db.SalesOrders.Find(id); // Mencari sales order berdasarkan ID
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder); // Tampilkan konfirmasi penghapusan
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            SalesOrder salesOrder = db.SalesOrders.Find(id); // Mencari sales order berdasarkan ID
            db.SalesOrders.Remove(salesOrder); // Hapus sales order dari database
            db.SaveChanges(); // Simpan perubahan
            return RedirectToAction("Index"); // Kembali ke daftar sales order
        }

        // Pastikan untuk membebaskan resource
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose(); // Lepaskan db context
            }
            base.Dispose(disposing);
        }
    }
}