using System.Collections.Generic;
using System.Linq;
using EPiServerSiteCMS.Models.ViewModels;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Catalog.Objects;
using Mediachase.Commerce.Orders;
using Mediachase.Commerce.Orders.Managers;
using Mediachase.Commerce.Security;
using Mediachase.Commerce.Website.Helpers;

namespace EPiServerSiteCMS.Business
{
	public class CartService
	{
		public decimal totalPrice;

		private readonly CartHelper _cartHelper;

        //Create a new cart for the logged user.
        public CartService(CartHelper cartHelper)
		{
			_cartHelper = cartHelper;
		    if (cartHelper == null)
		    {
		        var user = SecurityContext.Current.CurrentUserId;
		         _cartHelper = new CartHelper(Cart.DefaultName, user);
		    }
		}

        //Return the items from the current cart.
		public IEnumerable<LineItem> GetCartItems()
		{
			if (_cartHelper.IsEmpty)
			{
				return Enumerable.Empty<LineItem>();
			}
            
            return _cartHelper.LineItems;
        }
        // Return the total quantity of items in the shoppping Cart
        public decimal GetNumberOfItemsInCart()
        {
            decimal totalQuantity = 0;
            if (GetCartItems().Count() > 0)
            {
                foreach (var item in GetCartItems())
                {
                    totalQuantity += item.Quantity;
                }
            }
            
            return totalQuantity;
        }

        // Detele the cart.
        //User after the order was submited.
        public void DeleteCart()
        {
        	if (_cartHelper != null)
        	{
        		_cartHelper.Delete();
        	}
        }

        //Add a new entry in the cart.
        public LineItem GetLineItem(string stringcodeItem)
        {
        	var list = GetCartItems();
        	foreach (var item in list)
        	{
        		if (item.Code.Equals(stringcodeItem))
        		{
        			return item;
        		}
        	}
        	return null;
        }

        //Add an element to actual cart.
        public void AddToCart(string code, int quantity)
        {
        	Entry newEntry = CatalogContext.Current.GetCatalogEntry(code);
        	_cartHelper.AddEntry(newEntry, quantity, false);
        	_cartHelper.Cart.AcceptChanges(); 
        }

        //Compute the total price for the items in the cart.
        public decimal GetTotalPrice()
        {
        	if (_cartHelper.IsEmpty)
        	{
        		return 0;
        	}

        	foreach (var item in GetCartItems())
        	{
        		totalPrice = totalPrice + GetLineItemPrice(item.Code) * item.Quantity;
        	}
        	_cartHelper.Cart.Total = totalPrice;
        	return totalPrice;
        }

        // Get the price for corresponding variant given by the code.
        public decimal GetLineItemPrice(string code)
        {
        	var lineItemEntry = CatalogContext.Current.GetCatalogEntry(code);
        	var price = lineItemEntry.PriceValues.PriceValue[0].UnitPrice.Amount;
        	return price;
        }

        //Get the user cart.
        public Cart getCart()
        {
        	return _cartHelper.Cart;
        }

        // Merge annoymous cart with user cart after loggin.
        public void AppendToCart(Cart cartToAppend)
        {
            //merge
        	_cartHelper.Cart.Add(cartToAppend, true);
        	_cartHelper.Cart.AcceptChanges();

            //delete from anonymous cart
        	cartToAppend.Delete();
        	cartToAppend.AcceptChanges();
        }

        //Convert all the items from the cart into purchaseOrder items in order to ship them.
        //Send a notification email to user afer the order was placed.
        public void Checkout(CheckoutVM checkoutVM)
        {
        	PurchaseOrder purchaseOrder = _cartHelper.Cart.SaveAsPurchaseOrder();
            purchaseOrder.ShippingTotal = checkoutVM.Cart.TotalPrice;
            purchaseOrder.HandlingTotal = checkoutVM.Cart.ListOfItems.Count;
        	purchaseOrder.AcceptChanges();
        	OrderForm orderForm = purchaseOrder.OrderForms[0];
        	Shipment shipment = purchaseOrder.OrderForms[0].Shipments[0];

        	IEnumerable<LineItem> lineItems = GetCartItems();
        	foreach (var x in lineItems)
        	{
        		orderForm.LineItems.Add(x);
        	}

        	foreach (LineItem y in orderForm.LineItems)
        	{
        		PurchaseOrderManager.AddLineItemToShipment(purchaseOrder, y.LineItemId, shipment, y.Quantity);
        	}

        	orderForm.AcceptChanges();
        	purchaseOrder.OrderForms[0].Shipments.AcceptChanges();

        	Payment ThePayment = null;
        	OtherPayment otherPayment = new OtherPayment();
        	ThePayment = otherPayment;
        	ThePayment.TransactionType = TransactionType.Sale.ToString();
        	ThePayment.Status = PaymentStatus.Pending.ToString();
        	ThePayment.SetParent(orderForm);
        	ThePayment.AcceptChanges();
        	orderForm.Payments.Add(ThePayment);
        	
            MailSender mailSender = new MailSender();
            mailSender.SendMailToSpecificUser();
        }

        // Delete the item from submit button.
        public void RemoveItemFromCart(string code)
        {
            //out code = DisplayName -> see Index!
            var lineItem = GetCartItems().FirstOrDefault(i => i.Code == code);
            if (lineItem != null)
            {
                PurchaseOrderManager.RemoveLineItemFromOrder(_cartHelper.Cart, lineItem.LineItemId);
                _cartHelper.Cart.AcceptChanges();
            }
        }

        // Edit the item from submit button.
        public void EditItemFromCart(string code, decimal quantity)
        {
            if (quantity == 0)
            {
                RemoveItemFromCart(code);
            }
            else
            {
                var lineItem = GetCartItems().Where(i => i.Code == code).First();
                if (lineItem != null)
                {
                    lineItem.Quantity = quantity;
                    _cartHelper.Cart.AcceptChanges();
                }
            }
        }

    } //class end
}//namespace end
