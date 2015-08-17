using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiServerSiteCMS.Models.Blocks
{
    [ContentType(DisplayName = "AdressBlockType", GUID = "2a45e02a-2dbd-4655-a321-e1cacc35844e", Description = "")]
    public class AdressBlockType : BlockData
    {
        
                [CultureSpecific]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual String Name { get; set; }

         
                [CultureSpecific]
                [Display(
                    Name = "ZipCode",
                    Description = "ZipCode field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 3)]
                public virtual decimal ZipCode { get; set; }
         
    }
}