using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiServerSiteCMS.Models.Pages
{
    [ContentType(DisplayName = "CheckoutPage", GUID = "977290d5-5c98-4cc3-934b-ab6ecd2fe6d8", Description = "")]
    public class CheckoutPage : PageData
    {

        [Required]
        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        [Required]
        public virtual string Address { get; set; }

        [Required]
        public virtual string City { get; set; }

        [Required]
        public virtual string ZIPCode { get; set; }

    }
}