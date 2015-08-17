using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiServerSiteCMS.Models.Blocks
{
    [ContentType(DisplayName = "NavigationMenuBlock", GUID = "b87087d0-0567-4bf1-a782-63a0cf3c6003", Description = "")]
    public class NavigationMenuBlock : BlockData
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Parent Page",
            Description = "Select the parent of the pages you want to display.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual PageReference ParentPage { get; set; }
    }
}