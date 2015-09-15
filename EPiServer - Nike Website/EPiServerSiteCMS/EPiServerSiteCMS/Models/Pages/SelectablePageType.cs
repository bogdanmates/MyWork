using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiServerSiteCMS.Models.Pages
{
    [ContentType(DisplayName = "SelectablePageType", GUID = "cce63a04-4310-4336-9196-e5a9f8f9ea46", Description = "")]
    public class SelectablePageType : PageData
    {
        
                [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }

                [Display(Name = "Content area",
                Description = "A content for adding any shared block",
                GroupName = SystemTabNames.Content,
                Order = 4)]
                public virtual ContentArea ContentArea { get; set; }

    }
}