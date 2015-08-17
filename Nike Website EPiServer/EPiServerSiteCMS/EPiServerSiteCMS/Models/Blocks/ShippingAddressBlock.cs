using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiServerSiteCMS.Models.Blocks
{
    [ContentType(DisplayName = "ShippingAddressBlock", GUID = "f187c035-5f95-4e7b-ade6-da5bb0790fc8", Description = "")]
    public class ShippingAddressBlock : BlockData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual String Name { get; set; }
         */
    }
}