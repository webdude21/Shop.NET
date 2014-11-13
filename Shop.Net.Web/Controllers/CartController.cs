namespace Shop.Net.Web.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Model.Cart;
    using Shop.Net.Web.Areas.Catalog.Models.Product;
    using Shop.Net.Web.Models.Cart;
    using Shop.Net.Web.Models.Checkout;

    public class CartController : CustomerController
    {
        public CartController(IShopData shopData)
            : base(shopData)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(OrderOutputModel model)
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            var userId = this.User.Identity.GetUserId();
            var cart = this.ShopData.ShoppingCarts.All().FirstOrDefault(c => c.CustomerId == userId);

            if (cart == null || cart.CartItems.Count == 0)
            {
                return this.HttpNotFound(HttpStatusCode.BadRequest.ToString());
            }

            var orderOutputModel = new OrderOutputModel { CartId = cart.Id };

            return this.View(orderOutputModel);
        }

        public ActionResult Index()
        {
            var cart = this.GetCartViewModel();

            if (cart == null || cart.CartItems.Count < 1)
            {
                return this.View("Empty");
            }

            return this.View(cart);
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            var cartItem = this.ShopData.CartItems.Find(id);

            if (cartItem == null)
            {
                return this.HttpNotFound(HttpStatusCode.BadRequest.ToString());
            }

            this.ShopData.CartItems.Delete(cartItem.Id);
            this.ShopData.SaveChanges();

            return this.Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetCartItemsCount(string userId)
        {
            var cart = this.ShopData.ShoppingCarts.All().FirstOrDefault(x => x.CustomerId == userId);
            return this.Json(cart == null ? "0" : cart.CartItems.Count.ToString(CultureInfo.InvariantCulture), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ClearCart(int id)
        {
            var cart = this.ShopData.ShoppingCarts.All().FirstOrDefault(c => c.Id == id);

            if (cart == null)
            {
                return this.HttpNotFound(HttpStatusCode.BadRequest.ToString());
            }

            var cartItems = cart.CartItems.ToList();

            foreach (var item in cartItems)
            {
                this.ShopData.CartItems.Delete(item);
            }

            this.ShopData.SaveChanges();
            return this.View("Empty");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductDetailsViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.HttpNotFound();
            }

            var productToGoInTheCart = this.ShopData.Products.Find(model.Id);

            if (productToGoInTheCart == null)
            {
                return this.HttpNotFound();
            }

            var userId = this.User.Identity.GetUserId();
            this.CreateNewCartIfNeeded(userId);
            var entityCart = this.ShopData.ShoppingCarts.All().First(x => x.CustomerId == userId);
            entityCart.CartItems.Add(new CartItem
                                          {
                                              OrderedProduct = productToGoInTheCart,
                                              Quantity = model.OrderQuantity
                                          });

            this.ShopData.SaveChanges();
            var cart = this.GetCartViewModel();
            return this.Json(cart.CartItems.Count.ToString(CultureInfo.InvariantCulture));
        }

        private void CreateNewCartIfNeeded(string userId)
        {
            if (this.GetCartViewModel() == null)
            {
                this.ShopData.ShoppingCarts.Add(
                    new Cart
                    {
                        CustomerId = userId,
                        CreatedOnUtc = DateTime.UtcNow,
                    });

                this.ShopData.SaveChanges();
            }
        }

        private CartViewModel GetCartViewModel()
        {
            var userId = this.User.Identity.GetUserId();
            var cart = this.ShopData.ShoppingCarts.All()
                    .Where(x => x.CustomerId == userId)
                    .Project()
                    .To<CartViewModel>()
                    .FirstOrDefault();
            return cart;
        }
    }
}