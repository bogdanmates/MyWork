using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServerSiteCMS.Business;
using EPiServerSiteCMS.Models.JsonOrderItems;
using EPiServerSiteCMS.Models.Pages;

namespace EPiServerSiteCMS.Controllers
{
    public class SelectablePageTypeController : PageController<SelectablePageType>
    {
        public ActionResult Index(SelectablePageType currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            OrdersBL ordersBl = new OrdersBL();

            //READ COOKIE

            HttpCookie myCookie = new HttpCookie("LogCookie");
            myCookie = Request.Cookies["LogCookie"];

           

            List<JsonOrderItem> list = ordersBl.GetAllOrdersDetails(myCookie.Value);
            return View(currentPage);
        }
    }
}