using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace EPiServerSiteCMS.Models.Media
{
    [ContentType(DisplayName = "ImageFile", GUID = "3e32b6ae-a0b3-4c88-85e1-f31fbeae4a89", Description = "")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,gif,bmp,png")]
    public class ImageFile : ImageData
    {

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Description",
            Description = "Description field's description",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual String Description { get; set; }

    }
}