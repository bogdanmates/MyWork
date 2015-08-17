using System.Collections.Generic;
using EPiServer.Core;
using EPiServerSiteCMS.Models.Catalog;

namespace EPiServerSiteCMS.Business
{
    public interface IProductBL
    {
        List<string> GetAssetUrlsForVariant(NikeVariant variant);
        decimal GetVariantPrice(string code);
        NikeVariant GetAVariant(ContentReference contentReference);
        List<NikeVariant> GetAllVariantsForAllProducts();
        List<NikeVariant> GetAllVariantsForProduct(NikeProduct currentPage);
        List<NikeVariant> ReturnedList { get; set; }
    }
}
