using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShop.Models;

namespace EShop.Controllers
{
    public class CartItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CartItem
        public ActionResult Index()
        {
            var cartItems = db.CartItems.Include(c => c.Cart).Include(c => c.Product);
            return View(cartItems.ToList());
        }

        // GET: CartItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        // GET: CartItem/Create
        public ActionResult Create()
        {
            ViewBag.CartId = new SelectList(db.Carts, "Id", "UserId");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title");
            return View();
        }

        // POST: CartItem/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,ProductCount,CartId")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                db.CartItems.Add(cartItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CartId = new SelectList(db.Carts, "Id", "UserId", cartItem.CartId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", cartItem.ProductId);
            return View(cartItem);
        }

        // GET: CartItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CartId = new SelectList(db.Carts, "Id", "UserId", cartItem.CartId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", cartItem.ProductId);
            return View(cartItem);
        }

        // POST: CartItem/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,ProductCount,CartId")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CartId = new SelectList(db.Carts, "Id", "UserId", cartItem.CartId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", cartItem.ProductId);
            return View(cartItem);
        }

        // GET: CartItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        // POST: CartItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CartItem cartItem = db.CartItems.Find(id);
            db.CartItems.Remove(cartItem);
            db.SaveChanges();
            return RedirectToAction("Index");
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
