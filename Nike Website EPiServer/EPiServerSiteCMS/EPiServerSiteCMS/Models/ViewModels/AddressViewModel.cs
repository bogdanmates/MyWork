using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mediachase.BusinessFoundation.Blob.WebDavServer;
using System.ComponentModel.DataAnnotations;

namespace EPiServerSiteCMS.Models.ViewModels
{
    public class AddressViewModel
    {
        [Required]
         
        public string FirstName { get; set; }

        [Required]
         
        public string LastName { get; set; }

        [Required]
         
        public string Address { get; set; }

        [Required]
         
        public string City { get; set; }

        [Required]
         
        public string ZIPCode { get; set; }

        public string Type { get; set; }

        //public bool IsDefault { get; set; }

        public Guid AddressId { get; set; }
    }
}