using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;

namespace EPiServerSiteCMS.Models.Catalog
{
    //define a category
    [CatalogContentType(DisplayName = "NikeNode", GUID = "7193d12f-8406-4923-936b-c1993f785c26", Description = "NikeCatalogNode")]
    public class NikeNode : NodeContent
    {
        [Display(Name = "Description")]
        public virtual string Description { get; set; }
    }
}