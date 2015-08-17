using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServerSiteCMS.Models.Blocks;
using EPiServerSiteCMS.Models.Blocks.ViewModel;

namespace EPiServerSiteCMS.Controllers
{
    public class NavigationMenuBlockController : BlockController<NavigationMenuBlock>
    {
        public override ActionResult Index(NavigationMenuBlock currentBlock)
        {
            var pageChildren = Enumerable.Empty<PageData>();

            // Get the content repository
            IContentRepository contentRepository = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentRepository>();

            // Get the children of the page specified in the ParentPage property of the block
            if (!PageReference.IsNullOrEmpty(currentBlock.ParentPage))
            {
                pageChildren = contentRepository.GetChildren<PageData>(currentBlock.ParentPage);
            }

            return PartialView(new NavigationMenuViewModel(currentBlock,pageChildren));
        }
    }
}
