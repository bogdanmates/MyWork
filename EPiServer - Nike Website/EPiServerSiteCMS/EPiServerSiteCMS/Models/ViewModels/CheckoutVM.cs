using EPiServerSiteCMS.Models.CartModel;
using EPiServerSiteCMS.Models.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPiServerSiteCMS.Models.ViewModels
{
    public class CheckoutVM
    {
        public CartVM Cart { get; set; }

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