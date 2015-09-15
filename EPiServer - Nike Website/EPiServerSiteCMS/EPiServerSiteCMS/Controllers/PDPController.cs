using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServerSiteCMS.Business;
using EPiServerSiteCMS.Models.Pages;
using EPiServerSiteCMS.Models.ViewModels;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Website.Helpers;
using Mediachase.Commerce.Orders;

namespace EPiServerSiteCMS.Controllers
{
    public class PDPController : PageController<PDP>
    {
        public ActionResult Index(ContentReference contentReference)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            IProductBL _productBL = new ProductBL();
            var variant = _productBL.GetAVariant(contentReference);
           
            var itemPrice = _productBL.GetVariantPrice(variant.Code);
            var VMproduct = new ProductViewModel()
            {
                Code = variant.Code, ContentRef = variant.ContentLink, Details = variant.Details ,
                DisplayName = variant.DisplayName, Images = _productBL.GetAssetUrlsForVariant(variant),ImageProduct = variant.ImageProduct,
                Price = _productBL.GetVariantPrice(variant.Code), Color = variant.Color
            };

           //variant.VariantPrice = itemPrice;
            return View(VMproduct);
        }

        [HttpPost]
        public ActionResult AddToCart(int quantity, String code)
        {
            //added
            string Name = Session["newLoggedUser"] != null ? Session["newLoggedUser"].ToString() : Cart.DefaultName;
            //
            //modified
            //CartHelper cartHelper = new CartHelper(Cart.DefaultName);
            CartHelper cartHelper = new CartHelper(Name);
            //
            CartService cartService = new CartService(cartHelper);
            cartService.AddToCart(code, quantity);
            //return RedirectToAction("../ShoppingCart/Index");
            var numberOfItems = cartService.GetNumberOfItemsInCart();
            
            return Json(new {onSuccess = true, quantity = numberOfItems}, JsonRequestBehavior.AllowGet);
        }
    }
}