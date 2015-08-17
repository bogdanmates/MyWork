using System;
using System.Collections.Generic;
using System.Linq;
using EPiServerSiteCMS.Models.ViewModels;
using Mediachase.BusinessFoundation.Data;
using Mediachase.Commerce.Core;
using Mediachase.Commerce.Customers;

namespace EPiServerSiteCMS.Business
{
    public class CustomerService : ICustomerService
    {
        public AddressViewModel ConvertCustomerAddressToAddressViewModel(CustomerAddress address)
        {
            if (address == null) return null;

            var model = new AddressViewModel
            {
                AddressId = address.AddressId,
                City = address.City,
                Address = address.Name,
                FirstName = address.FirstName,
                LastName = address.LastName,
                ZIPCode = address.RegionCode,
                Type = address.AddressType.ToString()
            };
            return model;
        }

        public CustomerAddress ConvertAddressViewModelToCustomerAddress(AddressViewModel address)
        {
            var customerAddress = CustomerAddress.CreateInstance();
            if (address == null) return null;
            if (address.AddressId != Guid.Empty)
                customerAddress.AddressId = new PrimaryKeyId(address.AddressId);
            customerAddress.FirstName = address.FirstName;
            customerAddress.LastName = address.LastName;
            customerAddress.City = address.City;
            customerAddress.RegionCode = address.ZIPCode;
            customerAddress.Name = address.Address;
            var addressType = CustomerAddressTypeEnum.Billing;
            if (address.Type.Equals("Billing", StringComparison.OrdinalIgnoreCase))
            {
                addressType = CustomerAddressTypeEnum.Billing;
            }
            else
            {
                addressType = CustomerAddressTypeEnum.Shipping;
            }
            customerAddress.AddressType = addressType;

            return customerAddress;
        }

        public List<AddressViewModel> GetCurrentCustomerAddresses()
        {
            var addresses = new List<AddressViewModel>();
            if (CustomerContext.Current.CurrentContactId != Guid.Empty)
            {
                var contact = CustomerContext.Current.GetContactById(CustomerContext.Current.CurrentContactId);
                if (contact != null)
                {
                    var list = contact.ContactAddresses.ToList();
                    foreach (var item in list)
                    {
                        addresses.Add(ConvertCustomerAddressToAddressViewModel(item));
                    }
                }
            }
            return addresses;
        }

        public List<AddressViewModel> GetCurrentCustomerAddressesByType(string addressType)
        {
            var addresses = new List<AddressViewModel>();
            if (CustomerContext.Current.CurrentContactId != Guid.Empty)
            {
                var contact = CustomerContext.Current.GetContactById(CustomerContext.Current.CurrentContactId);
                if (contact != null)
                {
                    var list = contact.ContactAddresses.Where(addr => (addr.AddressType.ToString().Equals(addressType, StringComparison.OrdinalIgnoreCase)));
                    foreach (var item in list)
                    {
                        addresses.Add(ConvertCustomerAddressToAddressViewModel(item));
                    }
                }
            }
            return addresses;
        }

        public void SaveAddressToCurrentCustomer(AddressViewModel address)
        {
            if (CustomerContext.Current.CurrentContactId != Guid.Empty)
            {
                var contact = CustomerContext.Current.GetContactById(CustomerContext.Current.CurrentContactId);
                if (contact != null)
                {
                    contact.FirstName = address.FirstName;
                    contact.LastName = address.LastName;
                    contact.SaveChanges();

                    var billingAddress =
                        contact.ContactAddresses.FirstOrDefault(
                            a => a.AddressType.ToString().Equals("Billing", StringComparison.OrdinalIgnoreCase));
                    if (billingAddress != null)
                    {
                        UpdateAddress(address, billingAddress);
                    }
                    else
                    {
                        var shippingAddress =
                            contact.ContactAddresses.FirstOrDefault(
                            a => a.AddressType.ToString().Equals("Shipping", StringComparison.OrdinalIgnoreCase));
                        if (shippingAddress != null)
                        {
                            UpdateAddress(address,shippingAddress);
                        }
                    }
                }
                else
                {
                    CustomerAddress customerAddress =
                        CustomerAddress.CreateForApplication(AppContext.Current.ApplicationId);
                    customerAddress = ConvertAddressViewModelToCustomerAddress(address);
                    try
                    {
                        contact.AddContactAddress(customerAddress);
                        contact.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        public void UpdateAddressToCurrentCustomer(AddressViewModel address)
        {
            if (CustomerContext.Current.CurrentContactId != Guid.Empty)
            {
                var contact = CustomerContext.Current.GetContactById(CustomerContext.Current.CurrentContactId);
                if (contact != null)
                {
                    var savedAddress =
                        contact.ContactAddresses.FirstOrDefault(
                            a =>
                                a.AddressId.ToString()
                                    .Equals(address.AddressId.ToString(), StringComparison.OrdinalIgnoreCase));

                    UpdateAddress(address,savedAddress);
                }
            }
        }

        private void UpdateAddress(AddressViewModel address, CustomerAddress customerAddress)
        {
            if (CustomerContext.Current.CurrentContactId != Guid.Empty)
            {
                var contact = CustomerContext.Current.GetContactById(CustomerContext.Current.CurrentContactId);
                if (contact != null)
                {
                    customerAddress = ConvertAddressViewModelToCustomerAddress(address);
                    contact.UpdateContactAddress(customerAddress);
                    contact.SaveChanges();
                }
            }
        }
    }
}