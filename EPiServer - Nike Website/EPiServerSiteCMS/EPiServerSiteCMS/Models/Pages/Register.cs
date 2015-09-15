using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiServerSiteCMS.Models.Pages
{
    //register page
    [ContentType(DisplayName = "Register", GUID = "863f3714-a263-458d-bd29-ddf39bc082f9", Description = "")]
    public class Register : PageData
    {
        [Required]
        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        //added
        [Required]
        public virtual string ScreenName { get; set; }

        [Required]
        public virtual DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public virtual string Email { get; set; }

        //removed
        //[Required]
        //[EmailAddress]
        //public virtual string ConfirmEmail { get; set; }

        //removed
        //[Required]
        // public virtual string CellPhone { get; set; }

        [Required(AllowEmptyStrings = false)]
        public virtual string  ZipCode { get; set; }

        [Required]
        public virtual string Password { get; set; }

        [Required]
        public virtual string ConfirmPassword { get; set; }

        //added
        [Required]
        [MinLength(3)]
        public virtual string Gender { get; set; }
        
        //not used
        //purpose: display an error message
        public virtual string MessageToBeShown { get; set; }
    }
}