using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.Linking;
using EPiServer.Commerce.SpecializedProperties;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServerSiteCMS.Models.Catalog;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Catalog.Dto;

namespace EPiServerSiteCMS.Business
{
    /*
     * Business logic for the products.
     */
    public class ProductBL : IProductBL
    {
        public List<NikeVariant> ReturnedList { get; set; }


        // Contructor for business logic.
        // Instantiate return list attribute as null.
        public ProductBL()
        {
            ReturnedList = new List<NikeVariant>();
        }

        /*
         * Method that takes all the variants stores in the database for a specific product.
         * Return a list of nikeVariant items that coresspound to the product given reference.
         */
        public List<NikeVariant> GetAllVariantsForProduct(NikeProduct currentPage)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var referenceConverter = ServiceLocator.Current.GetInstance<ReferenceConverter>();

            //Get id of the given product reference.
            var itemId = referenceConverter.GetObjectId(currentPage.ContentLink);
            
            var productIdFromCommerce = itemId;
            var productLink = referenceConverter.GetContentLink(productIdFromCommerce, CatalogContentType.CatalogEntry,0);
            var productContent = contentLoader.Get<CatalogContentBase>(productLink);
            var prodCurrent = productContent.ContentLink;
            // Get all the children node for the current product.
            var linksRepository = ServiceLocator.Current.GetInstance<ILinksRepository>();
            var allRelations = linksRepository.GetRelationsBySource(prodCurrent);

            // Relations to Variations are of type ProductVariation
            var variations = allRelations.OfType<ProductVariation>().ToList();

            List<NikeVariant> variantsList = new List<NikeVariant>();
            
            //Construct the list of variants content.
            foreach (var item in variations)
            {
                variantsList.Add(contentLoader.Get<NikeVariant>(item.Target));
            }
            return variantsList;
        }

        /*
         * Return all variants for all products.
         * Return a list of nikeVariant.
         */
        public   List<NikeVariant> GetAllVariantsForAllProducts()
        {
            //Get the current content using service locator.
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            //Create a reference converter in order to get later a link from a reference.
            var referenceConverter = ServiceLocator.Current.GetInstance<ReferenceConverter>();
            //Get the current catalog DTO(Data Transfer Object) in order to acces the children nodes from it.
            CatalogDto dto = ServiceLocator.Current.GetInstance<ICatalogSystem>().GetCatalogDto();

            // Get the catalog link by getting the first catalog category.
            ContentReference catalogLink = referenceConverter.GetContentLink(dto.Catalog.First().CatalogId,
                CatalogContentType.Catalog, 0);
            //Get all childrens of the selected category represented by products links.
            IEnumerable<NodeContent> topCatalogNodes = contentLoader.GetChildren<NodeContent>(catalogLink).ToList();
            IEnumerable<NikeProduct> topCategoryNodes =
                contentLoader.GetChildren<NikeProduct>(topCatalogNodes.First().ContentLink).ToList();

            /*TIPS: Do a bit of research about entry nodes.*/

            //Iterate through every product.
            List<NikeVariant> variantsList = new List<NikeVariant>();
            foreach (var item in topCategoryNodes)
            {
                var itemId = referenceConverter.GetObjectId(item.ContentLink);
                var productLink = referenceConverter.GetContentLink(itemId, CatalogContentType.CatalogEntry, 0);
                var productContent = contentLoader.Get<CatalogContentBase>(productLink);
                var prodCurrent = productContent.ContentLink;
                var linksRepository = ServiceLocator.Current.GetInstance<ILinksRepository>();
                var allRelations = linksRepository.GetRelationsBySource(prodCurrent);
                var variations = allRelations.OfType<ProductVariation>().ToList();

                //Iterate through every variant of every product.
                // O(n2) complexity.
                foreach (var variant in variations)
                {
                    variantsList.Add(contentLoader.Get<NikeVariant>(variant.Target));
                }
            }

            return variantsList;
        }

        //Get a specific variant for a product reference.
        public NikeVariant GetAVariant(ContentReference contentReference)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var item = contentLoader.Get<CatalogContentBase>(contentReference);
            var variation = item.ContentLink;
            var variationContent = contentLoader.Get<NikeVariant>(variation);
            return variationContent;
        }

        //Get the price for a specific code of a variant.
        public decimal GetVariantPrice(string code)
        {
            var itemEntry = CatalogContext.Current.GetCatalogEntry(code);
            var price = itemEntry.PriceValues.PriceValue[0].UnitPrice.Amount;
            return price;
        }

        //Return all the media assets for a specific variant.
        public List<string> GetAssetUrlsForVariant(NikeVariant variant)
        {
            if (variant == null) return new List<string>();
            ItemCollection<CommerceMedia> mediaItems = variant.CommerceMediaCollection;
            if (mediaItems != null && mediaItems.Count > 0)
            {
                return mediaItems.Select(GetMediaUrl).ToList();
            }
            return new List<string>();
        }

        //Get the media assets.
        private string GetMediaUrl(CommerceMedia media)
        {
            if (media == null)
            {
                return String.Empty;
            }
            var _permanentLinkMapper = ServiceLocator.Current.GetInstance<PermanentLinkMapper>();

            PermanentLinkMap contentLinkMap = _permanentLinkMapper.Find(new Guid(media.AssetKey));
            if (contentLinkMap == null)
            {
                return String.Empty;
            }
            return contentLinkMap.MappedUrl.ToString();
        }
    }
}