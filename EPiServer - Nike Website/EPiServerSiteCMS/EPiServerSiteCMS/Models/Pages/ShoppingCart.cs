using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Commerce.Catalog.ContentTypes;
using System.Collections.Generic;
using Mediachase.Commerce.Orders;

namespace EPiServerSiteCMS.Models.Pages
{
    [ContentType(DisplayName = "ShoppingCart", GUID = "43a6cb69-20e8-4816-8b5a-63940e93ce29", Description = "")]
    public class ShoppingCart : PageData
    {

    }
}