using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServerSiteCMS.Models.Pages;
using EPiServerSiteCMS.Models.UserManagement;
using EPiServerSiteCMS.Business;
using Mediachase.Commerce.Website.Helpers;
using Mediachase.Commerce.Orders;

namespace EPiServerSiteCMS.Controllers
{
    public class LoginController : PageController<Login>
    {
        public ActionResult Index()
        {
           
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            //append anonymous cart to logged user's cart
            CartHelper _cartHelper = new CartHelper(Cart.DefaultName);
            CartService currentCart = new CartService(_cartHelper);
            //anonymous user's cart
            Cart theAnonymousCart = currentCart.getCart();

            Login loginVM = new Login();
            loginVM.Email = email;
            loginVM.Password = password;
            //check if user exists
            //and compare password with the stored one
            //returns true if everything's fine
            bool success = UserManager.ExistsUser(loginVM);
            if (success == true)
            {
                if (ModelState.IsValid)
                {
                    FormsAuthentication.SetAuthCookie(email, false);
                    //changed
                    //this.Session["newLoggedUser"] = DateTime.Now;
                    //if the user is logged, the email address
                    //is added to a cookie
                    this.Session["newLoggedUser"] = loginVM.Email;

                    //-----

                    HttpCookie myCookie = new HttpCookie("LogCookie");
                    DateTime now = DateTime.Now;

                    // Set the cookie value
                    myCookie.Value = loginVM.Email;
                    // Set the cookie expiration date
                    myCookie.Expires = now.AddMinutes(10000);

                    // Add the cookie.
                    Response.Cookies.Add(myCookie);

                    Response.Write("<p> The cookie has been written.");
                    //-----


                    //append to logged user's cart
                    CartHelper _cartHelper2 = new CartHelper(Session["newLoggedUser"].ToString());
                    CartService currentCart2 = new CartService(_cartHelper2);
                    currentCart2.AppendToCart(currentCart.getCart());
                    //

                    return RedirectToAction("Index", "NikeProductCMS");
                }
                else
                {
                    return RedirectToAction("Index", "Register");
                }
            }
            
                return RedirectToAction("Index", "Register");
           
        }
    }
}