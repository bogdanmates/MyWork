using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Mediachase.Commerce.Website.Helpers;
using Mediachase.Commerce.Orders;
using EPiServerSiteCMS.Business;
using EPiServerSiteCMS.Models.CartModel;
using EPiServerSiteCMS.Models.Pages;

namespace EPiServerSiteCMS.Controllers
{
    public class ShoppingCartController : PageController<ShoppingCart>
    {
        public ActionResult Index(ShoppingCart currentPage)
        {

            string Name = Session["newLoggedUser"] != null ? Session["newLoggedUser"].ToString() : Cart.DefaultName;
            CartHelper MyHelper = new CartHelper(Name);
            CartService cartService = new CartService(MyHelper);

            IEnumerable<LineItem> list = cartService.GetCartItems();
            List<CartItem> listCartItem = new List<CartItem>();
            var totalPrice = cartService.GetTotalPrice();

            foreach (var item in list)
            {
                var price = cartService.GetLineItemPrice(item.Code);
              //For items removing   cartService.RemoveLineItem(item.Code);
                listCartItem.Add(new CartItem(item.Code ,item.DisplayName, price, item.Quantity));
            }
            var cartModel = new CartVM()
            {
                ListOfItems = listCartItem,
                TotalPrice = totalPrice
            };
            return View(cartModel);
        }
        
         public ActionResult ModifyItem(string code, decimal quantity)
        {
            string name = (Session["newLoggedUser"] != null) ? Session["newLoggedUser"].ToString() : Cart.DefaultName;
            CartHelper _cartHelper = new CartHelper(name);
            CartService cartService = new CartService(_cartHelper);

            cartService.EditItemFromCart(code, quantity);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteItem(string code)
        {
            string name = (Session["newLoggedUser"] != null) ? Session["newLoggedUser"].ToString() : Cart.DefaultName;
            CartHelper _cartHelper = new CartHelper(name);
            CartService cartService = new CartService(_cartHelper);

            cartService.RemoveItemFromCart(code);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateShoppingCartItemsNumber()
        {
            string name = (Session["newLoggedUser"] != null) ? Session["newLoggedUser"].ToString() : Cart.DefaultName;
            CartHelper _cartHelper = new CartHelper(name);
            CartService cartService = new CartService(_cartHelper);

            var numberOfItems = cartService.GetNumberOfItemsInCart();


        }
    }
}
