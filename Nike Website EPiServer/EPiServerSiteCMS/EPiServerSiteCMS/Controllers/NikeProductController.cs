using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServerSiteCMS.Business;
using EPiServerSiteCMS.Models.Catalog;

namespace EPiServerSiteCMS.Controllers
{
    public class NikeProductController : ContentController<NikeProduct>
    {
        public ActionResult Index(NikeProduct currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return View(currentPage);
        }

        public ActionResult IndexVariantsList(NikeProduct currentContent)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            IProductBL _productBL = new ProductBL();
            List<NikeVariant> returnedList = _productBL.GetAllVariantsForProduct(currentContent);
            _productBL.ReturnedList = returnedList;
            return View(returnedList);
        }
    }
}