using System.Collections.Generic;
using System.Linq;
using EPiServerSiteCMS.Models.JsonOrderItems;
using Mediachase.Commerce.Orders;
using Mediachase.Commerce.Security;

namespace EPiServerSiteCMS.Business
{   
     /*
      Business logic layer for the orders.
      */
    public class OrdersBL
    {
        /*
         Method that gets all orders for the current user and return a list of purchase order elements. 
         */
        public PurchaseOrder[] GetAllOrders()
        {
            PurchaseOrder[] orders = null;

            // verify if there is a logged user. In other case doesn't display the order list.
            if (SecurityContext.Current.CurrentUserId != null)
            {
                //collect the list of orders for the current logged user.
                orders = OrderContext.Current.GetPurchaseOrders(SecurityContext.Current.CurrentUserId).ToArray();
                var ownerName = orders[0].CustomerName;
                var tranckingNumber = orders[0].TrackingNumber;
                var expData = orders[0].ExpirationDate;
                var currency = orders[0].BillingCurrency;
                var totalAmmountSum = orders[0].HandlingTotal;
                var totalAmmountItems = orders[0].ShippingTotal;
            }
            return orders;
        }

        /*
         Get all orders for the current logged user and return a list of details for every order.
         * Requires the email of the current user stored in the cookie after login.
         */
        public List<JsonOrderItem> GetAllOrdersDetails(string cookieUserName)
        {
            PurchaseOrder[] orders = null;

            List<JsonOrderItem> list = new List<JsonOrderItem>();
            if (SecurityContext.Current.CurrentUserId != null)
            {

                orders = OrderContext.Current.GetPurchaseOrders(SecurityContext.Current.CurrentUserId).ToArray();
                //Collect for every order item the important details.
                foreach (var orderItem in orders)
                {
                    var ownerName = orderItem.CustomerName;
                    var tranckingNumber = orderItem.TrackingNumber;
                    var expData = orderItem.ExpirationDate;
                    var currency = orderItem.BillingCurrency;
                    var totalAmmountSum = orderItem.ShippingTotal;
                    var totalAmmountItems = orderItem.HandlingTotal;
                    
                    //Create a wrapper object with the details collected before.
                    JsonOrderItem jsonOrderItemsList = new JsonOrderItem();
                  
                    jsonOrderItemsList.ownerName = orderItem.CustomerName;
                    jsonOrderItemsList.tranckingNumber = tranckingNumber;
                    jsonOrderItemsList.expData = expData.ToString();
                    jsonOrderItemsList.totalAmmountItems = totalAmmountItems.ToString("F");

                    // Remove the float decimals from the number of items in the cart by returning a substring.
                    int lengthOfTotalItems = jsonOrderItemsList.totalAmmountItems.Length;
                    jsonOrderItemsList.totalAmmountItems = jsonOrderItemsList.totalAmmountItems.Substring(0,
                        lengthOfTotalItems - 2);

                    jsonOrderItemsList.totalAmmountSum = totalAmmountSum.ToString("F");
                    jsonOrderItemsList.currency = currency;

                    //Add new order details to list.
                    list.Add(jsonOrderItemsList);
                }
            }

            //Set the owner name for the current order as founded email value.
            var listLength = list.Count -1;
            list[listLength].ownerName = cookieUserName;
            return list;
        }
    }
}