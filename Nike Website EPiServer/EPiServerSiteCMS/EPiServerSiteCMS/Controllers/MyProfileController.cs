using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServerSiteCMS.Models.Pages;

namespace EPiServerSiteCMS.Controllers
{
    public class MyProfileController : PageController<MyProfilePage>
    {
        public ActionResult Index(MyProfilePage currentPage)
        {
            

            return View(currentPage);
        }

        
    }
}