using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiServerSiteCMS.Models.Pages
{
    //login page
    [ContentType(DisplayName = "Login", GUID = "ef3f0684-28f3-40ff-85bb-c52c3695b1fb", Description = "")]
    public class Login : PageData
    {
        [Required]
        [EmailAddress]
        public virtual string Email { get; set; }

        [Required]
        public virtual string Password { get; set; }
    }
}