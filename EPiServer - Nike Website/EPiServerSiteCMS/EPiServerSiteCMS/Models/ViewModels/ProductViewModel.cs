using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;

namespace EPiServerSiteCMS.Models.ViewModels
{
    public class ProductViewModel
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public virtual ContentReference ImageProduct { get; set; }
        public List<string> Images { get; set; }
        public ContentReference ContentRef { get; set; }
        public string Color { get; set; }
    }
}