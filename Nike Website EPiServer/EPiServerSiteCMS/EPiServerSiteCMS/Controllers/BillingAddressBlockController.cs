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
using EPiServerSiteCMS.Models.ViewModels;
using Mediachase.Commerce.Customers;
using Mediachase.Commerce.Customers.Profile;
using Mediachase.Commerce.Orders;
using Mediachase.Commerce.Website.Helpers;
using Mediachase.Commerce.Security;

namespace EPiServerSiteCMS.Controllers
{
    public class BillingAddressBlockController : BlockController<BillingAddressBlock>
    {
        private ICustomerService _customerService = new CustomerService();
       
        public override ActionResult Index(BillingAddressBlock currentBlock)
        {
            
            var address = _customerService.GetCurrentCustomerAddressesByType("Billing");

            if (address.Count > 0)
            {
                return View(address.First());
            }

            return View(new AddressViewModel(){AddressId = Guid.NewGuid()});
        }

        
        public ActionResult Edit()
        {

            var address = _customerService.GetCurrentCustomerAddressesByType("Billing");

            if (address.Count > 0)
            {
                return View(address.First());
            }

            return View(new AddressViewModel() { AddressId = Guid.NewGuid() });
        }

        [HttpPost]
        public ActionResult Submit(string firstName, string lastName,string address, string city, string zipCode,Guid addressId)
        {
              var billingAddress = _customerService.GetCurrentCustomerAddressesByType("Billing");

                var addressViewModel = new AddressViewModel()
                {
                    AddressId = addressId,
                    Type = "Billing",
                    Address = address,
                    City = city,
                    LastName = lastName,
                    FirstName = firstName,
                    ZIPCode = zipCode
                };

            if(ModelState.IsValid){
                if (billingAddress.Count() > 0)
                {

                    _customerService.UpdateAddressToCurrentCustomer(addressViewModel);

                    return RedirectToAction("Index",new BillingAddressBlock());
                }
                else
                {
                    _customerService.SaveAddressToCurrentCustomer(addressViewModel);

                    return RedirectToAction("Index", new BillingAddressBlock());
                }
            }
            return View("Edit", addressViewModel);

        }
    }
}
