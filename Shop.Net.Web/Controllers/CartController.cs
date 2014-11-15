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
    using Shop.Net.Model.Order;
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
            var userId = this.User.Identity.GetUserId();
            var cart = this.ShopData.ShoppingCarts.All().FirstOrDefault(c => c.CustomerId == userId);

            if (cart == null && cart.CartItems.Count == 0)
            {
                return this.View("Empty");
            }

            if (this.ModelState.IsValid)
            {
                this.CreateNewOrder(model, userId, cart);
                this.ShopData.SaveChanges();
                this.EmptyCart(cart.Id);
            }
            else
            {
                return this.View(model);
            }

            return this.View("Success");
        }

        private void CreateNewOrder(OrderOutputModel model, string userId, Cart cart)
        {
            var order = new Order
                          {
                              CarrierId = model.CarrierId,
                              ShippingInformationId = model.ShippingInformationId,
                              OrderStatus = OrderStatus.AwatingForPaymentConfirmation,
                              CreatedOnUtc = DateTime.UtcNow,
                              UpdatedOnUtc = DateTime.UtcNow,
                              CustomerId = userId,
                          };

            this.ShopData.Orders.Add(order);

            foreach (var item in cart.CartItems)
            {
                order.OrderItems.Add(new OrderItem { OrderedProductId = item.OrderedProductId, Quantity = item.Quantity });
            }

            this.ShopData.SaveChanges();
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            var userId = this.User.Identity.GetUserId();
            var cart = this.ShopData.ShoppingCarts.All().FirstOrDefault(c => c.CustomerId == userId);

            if (cart == null || cart.CartItems.Count == 0)
            {
                return this.View("Empty");
            }

            return this.View(new OrderOutputModel());
        }

        [HttpGet]
        public ActionResult ReadShippingInformation()
        {
            var userId = this.User.Identity.GetUserId();
            var addresses =
                this.ShopData.ContactInformations.All()
                    .Where(x => x.CustomerId == userId)
                    .Project()
                    .To<ContactInformationDropdownViewModel>()
                    .ToList();

            return this.Json(addresses, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ReadCarrierInformation()
        {
            return this.Json(
                this.ShopData.Carrier.All().Project().To<CarrierDropdownViewModel>(),
                JsonRequestBehavior.AllowGet);
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
            return this.Json(
                cart == null ? "0" : cart.CartItems.Count.ToString(CultureInfo.InvariantCulture),
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ClearCart(int cartId)
        {
            this.EmptyCart(cartId);
            return this.View("Empty");
        }

        private void EmptyCart(int id)
        {
            var cart = this.ShopData.ShoppingCarts.All().FirstOrDefault(c => c.Id == id);

            var cartItems = cart.CartItems.ToList();

            foreach (var item in cartItems)
            {
                this.ShopData.CartItems.Delete(item);
            }

            this.ShopData.SaveChanges();
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
            entityCart.CartItems.Add(
                new CartItem { OrderedProduct = productToGoInTheCart, Quantity = model.OrderQuantity });

            this.ShopData.SaveChanges();
            var cart = this.GetCartViewModel();
            return this.Json(cart.CartItems.Count.ToString(CultureInfo.InvariantCulture));
        }

        private void CreateNewCartIfNeeded(string userId)
        {
            if (this.GetCartViewModel() == null)
            {
                this.ShopData.ShoppingCarts.Add(new Cart { CustomerId = userId, CreatedOnUtc = DateTime.UtcNow, });

                this.ShopData.SaveChanges();
            }
        }

        private CartViewModel GetCartViewModel()
        {
            var userId = this.User.Identity.GetUserId();
            var cart =
                this.ShopData.ShoppingCarts.All()
                    .Where(x => x.CustomerId == userId)
                    .Project()
                    .To<CartViewModel>()
                    .FirstOrDefault();
            return cart;
        }
    }
}