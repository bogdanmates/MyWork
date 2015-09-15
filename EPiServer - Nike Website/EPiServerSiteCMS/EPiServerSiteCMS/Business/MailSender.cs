using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using EPiServerSiteCMS.Models.JsonOrderItems;
using Mediachase.Commerce.Security;

namespace EPiServerSiteCMS.Business
{
    /*
     * Send emails after the order is confirmed. Sends to the logged user the notification email 
     */
    public class MailSender
    {
        /*
         The method sends all orders stored in the database to the test email.
         * It uses security context in order to take the current logged user.
         */
        public void SendMail()
        {
            //Create a new smtp client. Set the credentials for the host user.
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("testTechromX@gmail.com", "testTechromX123");

            // Call the business login in order to take all the order details for the current user.
            OrdersBL ordersBl = new OrdersBL();
            List<JsonOrderItem> orderItemList = ordersBl.GetAllOrdersDetails( SecurityContext.Current.CurrentUserName);

            // Create the string that will be the body of the sended mail by iterating every order element from the taken list.
            String bodyString = null;
            foreach (var itemOrder in orderItemList)
            {
                String lineString = null;
                lineString = "Owner Name: " + itemOrder.ownerName + "\n" + "Expiration Data: " + itemOrder.expData + "\n" +
                    "Tracking Number: " + itemOrder.tranckingNumber + "\n" + "Total Number Of Items: " + itemOrder.totalAmmountItems +"\n"+
                    "Total Sum " + itemOrder.totalAmmountSum + itemOrder.currency + "\n";
                bodyString += "\n" + lineString;
            }

            //Sends the mail to the implicit writed test account.
            MailMessage mm = new MailMessage("testTechromX@gmail.com", "testTechromX@gmail.com", "YourEpiServerOrder", bodyString);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mm);
        }


        /*
       The method sends all orders stored in the database to the test email.
       * It uses security context in order to take the current logged user.
       */
        public void SendMailToSpecificUser()
        {
            //Create a new smtp client. Set the credentials for the host user.
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("testTechromX@gmail.com", "testTechromX123");

            // Call the business login in order to take all the order details for the current user.
            OrdersBL ordersBl = new OrdersBL();
            List<JsonOrderItem> orderItemList = ordersBl.GetAllOrdersDetails(SecurityContext.Current.CurrentUserName);

            // Create the string that will be the body of the sended mail by iterating every order element from the taken list. The body message will be only  the last element
            // from the order list.(last item in order history)
            String bodyString = null;
            JsonOrderItem itemOrder = null;
            foreach (var item in orderItemList)
            {
                itemOrder = item;
            }

            String lineString = null;
                lineString = "Owner Name: " + itemOrder.ownerName + "\n" + "Expiration Data: " + itemOrder.expData + "\n" +
                    "Tracking Number: " + itemOrder.tranckingNumber + "\n" +
                    "Total Sum " + itemOrder.totalAmmountSum + itemOrder.currency + "\n";
                bodyString += "\n" + lineString;

                bodyString += "\n" + "Regards, " +"\n" + "Interns Team";

            //Sends the mail to the logged account user. Current user name correspounds with the email attached to the logged user.
            MailMessage mm = new MailMessage("testTechromX@gmail.com", SecurityContext.Current.CurrentUserName, "YourEpiServerOrder", bodyString);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }

    }
}