using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiServerSiteCMS.Models.Pages
{
    public class CartItem
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public CartItem(string c, string d, decimal p, decimal q)
        {
            Code = c;
            DisplayName = d;
            Price = p;
            Quantity = q;
        }
    }
}