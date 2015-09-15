using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiServerSiteCMS.Models.Pages
{
    [ContentType(DisplayName = "MyProfile", GUID = "89455b4f-569c-4f02-b88d-cab1692b9c56", Description = "")]
    /*[MediaDescriptor(ExtensionString = "pdf,doc,docx")]*/
    public class MyProfilePage : PageData
    {
        [CultureSpecific]
        [Display(
               Name = "Title",
               Description = "Title of the page",
               GroupName = SystemTabNames.Content,
               Order = 1)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "ContentArea",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual ContentArea MainContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Left menu",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual ContentArea LeftMenu { get; set; }
        
    }
}