using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EShop.Models;
using Microsoft.AspNet.Identity;

namespace EShop.Controllers
{
    public class CartItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CartItem
        public ActionResult Index()
        {
            var cartItems = new List<CartItem>();
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var cart = db.Carts.FirstOrDefault(x => x.UserId == userId);
                if (cart != null)
                {
                    var cartItems0 = db.CartItems.Include(c => c.Cart).Include(c => c.Product).ToList();
                    cartItems = cartItems0.Where(x => x.CartId == cart.Id).ToList();
                }
            }
            return View(cartItems.ToList());
        }

        // GET: CartItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cartItems = db.CartItems.Include(c => c.Cart).Include(c => c.Product).ToList();
            var cartItem = cartItems.FirstOrDefault(x => x.Id ==id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
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
