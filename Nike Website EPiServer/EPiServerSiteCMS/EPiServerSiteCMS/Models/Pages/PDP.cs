using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace EPiServerSiteCMS.Models.Pages
{
    [ContentType(DisplayName = "PDP", GUID = "5e3eb9c0-1777-4ba3-8b5c-2653e10708f4", Description = "")]
    public class PDP : PageData
    {

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }


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