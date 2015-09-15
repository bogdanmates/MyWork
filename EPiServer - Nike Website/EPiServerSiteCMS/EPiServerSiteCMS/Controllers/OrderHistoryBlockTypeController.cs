using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServerSiteCMS.Business;
using EPiServerSiteCMS.Models.Blocks;
using EPiServerSiteCMS.Models.JsonOrderItems;

namespace EPiServerSiteCMS.Controllers
{
    public class OrderHistoryBlockTypeController : BlockController<OrderHistoryPageBlock>
    {
        public override ActionResult Index(OrderHistoryPageBlock currentBlock)
        {

            //READ COOKIE

            HttpCookie myCookie = new HttpCookie("LogCookie");
            myCookie = Request.Cookies["LogCookie"];
            /*
            // Read the cookie information and display it.
            if (myCookie != null)
                Response.Write("<p>" + myCookie.Name + "<p>" + myCookie.Value);
            else
                Response.Write("not found");
            //-----
            */

            OrdersBL ordersBL = new OrdersBL();
            List<JsonOrderItem> listOfOrders = ordersBL.GetAllOrdersDetails(myCookie.Value);
            return PartialView(listOfOrders);
        }
    }
}
