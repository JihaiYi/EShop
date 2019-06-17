using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShop.Models;
using Microsoft.AspNet.Identity;


namespace EShop.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public int ProductCount()   //购物车中的产品数量 
         { 
             if (!User.Identity.IsAuthenticated) 
             { 
                 return 0; 
             } 
 
              var userId = User.Identity.GetUserId(); 
              var cart = db.Carts.FirstOrDefault(x => x.UserId == userId); 
              if (cart == null) 
              { 
                  return 0; 
              } 
              var cartItems = db.CartItems.ToList(); 
              var userCartItems = cartItems.Where(x => x.CartId == cart.Id).ToList(); 
              return userCartItems.Sum(x => x.ProductCount); 
  
 
          } 
  
 
  
 
          public ActionResult AjaxAddToCart(int id)
          { 
              if (!User.Identity.IsAuthenticated) 
              { 
                  return JavaScript("window.location = 'Account/Login'"); 
              } 
              var userId = User.Identity.GetUserId(); 
              var cart = db.Carts.FirstOrDefault(x => x.UserId == userId); 
              if (cart == null) 
              { 
                  cart = new Cart 
                  { 
                     UserId = userId 
                 }; 
                  db.Carts.Add(cart); 
                  db.SaveChanges(); 
             } 
 
 
              var cartItem0 = db.CartItems
                               .FirstOrDefault(x => x.ProductId == id && x.CartId == cart.Id); 
             if (cartItem0 == null) 
              { 
                  var cartItem = new CartItem
                  { 
                      ProductId = id, 
                     ProductCount = 1, 
                     CartId = cart.Id 
                }; 
                 db.CartItems.Add(cartItem); 
              } 
              else 
              { 
                  cartItem0.ProductCount = cartItem0.ProductCount + 1; 
             } 
              db.SaveChanges(); 
             return View(ProductCount()); 
          } 





        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Price,ImageUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Price,ImageUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
