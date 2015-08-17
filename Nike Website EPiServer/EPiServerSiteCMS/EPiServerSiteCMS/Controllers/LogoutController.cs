using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;

namespace EPiServerSiteCMS.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Logout()
        {
            //empty the session -> back to anonymous user
            Session["newLoggedUser"] = null;
            return RedirectToAction("Index", "StartPage");
        }
    }
}