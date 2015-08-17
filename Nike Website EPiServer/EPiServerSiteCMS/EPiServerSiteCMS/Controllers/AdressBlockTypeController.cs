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

namespace EPiServerSiteCMS.Controllers
{
    public class AdressBlockTypeController : BlockController<AdressBlockType>
    {
        public override ActionResult Index(AdressBlockType currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}
