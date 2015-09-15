using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServerSiteCMS.Models.ViewModels;
using EPiServerSiteCMS.Business;
using EPiServerSiteCMS.Models.Blocks;

namespace EPiServerSiteCMS.Controllers
{
    public class ShippingAddressBlockController : BlockController<ShippingAddressBlock>
    {
        private ICustomerService _customerService = new CustomerService();

        public override ActionResult Index(ShippingAddressBlock currentBlock)
        {

            var address = _customerService.GetCurrentCustomerAddressesByType("Shipping");

            if (address.Count > 0)
            {
                return View(address.First());
            }

            return View(new AddressViewModel() { AddressId = Guid.NewGuid() });
        }

        public ActionResult Edit()
        {

            var address = _customerService.GetCurrentCustomerAddressesByType("Shipping");

            if (address.Count > 0)
            {
                return View(address.First());
            }

            return View(new AddressViewModel() { AddressId = Guid.NewGuid() });
        }

        
        [HttpPost]
        public ActionResult Submit(string firstName, string lastName, string address, string city, string zipCode, Guid addressId)
        {
            var ShippingAddress = _customerService.GetCurrentCustomerAddressesByType("Shipping");

            var addressViewModel = new AddressViewModel()
            {
                AddressId = addressId,
                Type = "Shipping",
                Address = address,
                City = city,
                LastName = lastName,
                FirstName = firstName,
                ZIPCode = zipCode
            };

            if (ModelState.IsValid)
            {
                if (ShippingAddress.Count() > 0)
                {

                    _customerService.UpdateAddressToCurrentCustomer(addressViewModel);

                    return RedirectToAction("Index", new ShippingAddressBlock());
                }
                else
                {
                    _customerService.SaveAddressToCurrentCustomer(addressViewModel);

                    return RedirectToAction("Index", new ShippingAddressBlock());
                }
            }
            return View("Edit", addressViewModel);

        }
    }
}
