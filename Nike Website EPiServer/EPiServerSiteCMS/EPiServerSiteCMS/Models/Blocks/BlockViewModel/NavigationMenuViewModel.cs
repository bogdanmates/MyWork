using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mediachase.BusinessFoundation.Blob.WebDavServer;
using EPiServer.Core;

namespace EPiServerSiteCMS.Models.Blocks.ViewModel
{
    public class NavigationMenuViewModel
    {
        public NavigationMenuBlock NavMenuBlock { get; set; }

        public IEnumerable<PageData> PageChildren { get; set; }

        public NavigationMenuViewModel(NavigationMenuBlock navMenuBlock, IEnumerable<PageData> pageChildren)
        {
            NavMenuBlock = navMenuBlock;
            PageChildren = pageChildren;
        }
    }
}