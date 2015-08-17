using System.Collections.Generic;
using EPiServerSiteCMS.Models.ViewModels;
using Mediachase.Commerce.Customers;

namespace EPiServerSiteCMS.Business
{
    public interface ICustomerService
    {
        AddressViewModel ConvertCustomerAddressToAddressViewModel(CustomerAddress address);
        CustomerAddress ConvertAddressViewModelToCustomerAddress(AddressViewModel address);
        List<AddressViewModel> GetCurrentCustomerAddresses();
        List<AddressViewModel> GetCurrentCustomerAddressesByType(string addressType);
        void SaveAddressToCurrentCustomer(AddressViewModel address);
        void UpdateAddressToCurrentCustomer(AddressViewModel address);
    }
}
