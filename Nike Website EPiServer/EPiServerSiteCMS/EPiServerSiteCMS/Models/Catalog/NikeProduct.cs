using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace EPiServerSiteCMS.Models.Catalog
{
    //define a product
    [CatalogContentType(DisplayName = "NikeProduct", GUID = "34c9b125-35d5-4313-acd9-15300eb01328", MetaClassName = "NikeProductMetaClass")]
    public class NikeProduct : ProductContent
    {
        [Display(Name = "Category")]
        public virtual string Category { get; set; }

        [Display(Name = "Main Content")]
        [CultureSpecific]
        public virtual XhtmlString MainContent { get; set; }
    }
}