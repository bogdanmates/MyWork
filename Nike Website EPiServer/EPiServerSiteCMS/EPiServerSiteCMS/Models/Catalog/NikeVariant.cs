using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace EPiServerSiteCMS.Models.Catalog
{
    //define a variant
    [CatalogContentType(DisplayName = "NikeVariant", GUID = "f17413f8-71e1-4c3d-8cc7-c26a7895be5a", MetaClassName = "NikeProduct")]
    public class NikeVariant : VariationContent
    {
        [Display(Name = "Name")]
        public virtual String VariantName { get; set; }

        [Display(Name = "Color")]
        public virtual string Color { get; set; }

        [UIHint(UIHint.Image)]
        [Display(Name = "ImageProduct")]
        public virtual ContentReference ImageProduct { get; set; }

        [Display(Name = "Details")]
        public virtual string Details { get; set; }

        [Display(Name = "VariantPrice")]
        public virtual decimal VariantPrice { get; set; }
    }
}