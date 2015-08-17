using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServerSiteCMS.Models.Pages;
using EPiServerSiteCMS.Models.ViewModels;
using EPiServerSiteCMS.Models.CartModel;
using Mediachase.Commerce.Orders;
using Mediachase.Commerce.Website.Helpers;
using EPiServerSiteCMS.Business;
using System.Web;
using System;

namespace EPiServerSiteCMS.Controllers
{
    public class CheckoutController : PageController<CheckoutPage>
    {
        [HttpPost]
        public ActionResult Index()
        {
            //added
            string Name = Session["newLoggedUser"] != null ? Session["newLoggedUser"].ToString() : Cart.DefaultName;
            //
            //CartHelper MyHelper = new CartHelper(Cart.DefaultName);
            //added
            CartHelper MyHelper = new CartHelper(Name);
            //
            CartService cartService = new CartService(MyHelper);

            IEnumerable<LineItem> list = cartService.GetCartItems();
            if (list.Count() == 0)
            {
                return RedirectPermanent("~/ShoppingCart/Index");
            }
            List<CartItem> listCartItem = new List<CartItem>();
            var totalPrice = cartService.GetTotalPrice();

            foreach (var item in list)
            {
                var price = cartService.GetLineItemPrice(item.Code);
                //For items removing   cartService.RemoveLineItem(item.Code);
                listCartItem.Add(new CartItem(item.Code, item.DisplayName, price, item.Quantity));
            }
            var model = new CheckoutVM
            {
                Cart = new CartVM { ListOfItems = listCartItem, TotalPrice = totalPrice }
            };

          //  OrdersBL orderbl = new OrdersBL();
          //  var listOrders = orderbl.GetAllOrders();

            return View(model);
        }

        [HttpPost]
        public ActionResult Submit(CheckoutVM checkoutVM)
        {
            string Name = Session["newLoggedUser"] != null ? Session["newLoggedUser"].ToString() : Cart.DefaultName;
            //
            //CartHelper MyHelper = new CartHelper(Cart.DefaultName);
            //added
            CartHelper MyHelper = new CartHelper(Name);
            //
            CartService cartService = new CartService(MyHelper);

            IEnumerable<LineItem> list = cartService.GetCartItems();
            List<CartItem> listCartItem = new List<CartItem>();
            var totalPrice = cartService.GetTotalPrice();

            foreach (var item in list)
            {
                var price = cartService.GetLineItemPrice(item.Code);
                //For items removing   cartService.RemoveLineItem(item.Code);
                listCartItem.Add(new CartItem(item.Code, item.DisplayName, price, item.Quantity));
            }

            checkoutVM.Cart = new CartVM { ListOfItems = listCartItem, TotalPrice = totalPrice };
            if (ModelState.IsValid)
            {
                cartService.Checkout(checkoutVM);
                cartService.DeleteCart();

                return View(checkoutVM);
            }
            return View("Index", checkoutVM);
        }
    }
}