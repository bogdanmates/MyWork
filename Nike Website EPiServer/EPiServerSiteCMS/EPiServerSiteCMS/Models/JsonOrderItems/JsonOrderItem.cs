using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiServerSiteCMS.Models.JsonOrderItems
{
    public class JsonOrderItem
    {
        public string ownerName { get; set; }
        public string tranckingNumber { get; set; }
        public string expData { get; set; }
        public string totalAmmountItems { get; set; }
        public string totalAmmountSum { get; set; }
        public string currency { get; set; }
    }
}