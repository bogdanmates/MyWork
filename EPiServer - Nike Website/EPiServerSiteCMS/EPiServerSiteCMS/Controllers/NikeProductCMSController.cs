using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServerSiteCMS.Business;
using EPiServerSiteCMS.Models.Pages;
using EPiServerSiteCMS.Models.ViewModels;

namespace EPiServerSiteCMS.Controllers
{
    public class NikeProductCMSController : PageController<NikeProductCMS>
    {
        public ActionResult Index(NikeProductCMS currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            IProductBL _productBL = new ProductBL();
            
            var variationList = _productBL.GetAllVariantsForAllProducts();
            var productList = new List<ProductViewModel>();
            foreach (var item in variationList)
            {
                productList.Add(new ProductViewModel
                {
                    DisplayName = item.DisplayName,
                    Details = item.Details,
                    Code = item.Color,
                    Price = _productBL.GetVariantPrice(item.Code),
                    Images = _productBL.GetAssetUrlsForVariant(item),
                    ImageProduct = item.ImageProduct,
                    ContentRef = item.ContentLink
                });
            }

            return View(productList);
        }
    }
}