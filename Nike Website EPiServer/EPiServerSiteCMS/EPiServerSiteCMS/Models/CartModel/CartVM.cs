using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServerSiteCMS.Models.Pages;

namespace EPiServerSiteCMS.Models.CartModel
{
    public class CartVM
    {
        public List<CartItem> ListOfItems { get; set; }
        public decimal TotalPrice {get; set; }
    }
}