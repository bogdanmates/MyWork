using System.Collections.Generic;
using EPiServerSiteCMS.Models.ViewModels;
using Mediachase.Commerce.Orders;
using Mediachase.Commerce.Website.Helpers;

namespace EPiServerSiteCMS.Business
{
    public interface ICartService
    {
        IEnumerable<LineItem> GetCartItems();
        decimal GetNumberOfItemsInCart();
        void DeleteCart();
        LineItem GetLineItem(string stringcodeItem);
        void AddToCart(string code, int quantity);
        decimal GetTotalPrice();
        decimal GetLineItemPrice(string code);
        void AppendToCart(Cart cartToAppend);
        void Checkout(CheckoutVM checkoutVM);
        void RemoveItemFromCart(string code);
        void EditItemFromCart(string code, decimal quantity);

    }
}
