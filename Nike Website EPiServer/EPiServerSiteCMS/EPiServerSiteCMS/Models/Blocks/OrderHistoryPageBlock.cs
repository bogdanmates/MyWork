using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiServerSiteCMS.Models.Blocks
{
    [ContentType(DisplayName = "OrderHistoryPageBlock", GUID = "54d9d4f4-e2a2-4cd7-be7c-a665b5f772cd", Description = "")]
    public class OrderHistoryPageBlock : BlockData
    {
        
                [CultureSpecific]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual String Name { get; set; }
         
    }
}