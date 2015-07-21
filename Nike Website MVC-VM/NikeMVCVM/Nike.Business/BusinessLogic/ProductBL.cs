using Nike.Business.ViewModels;
using Nike.DataLayer.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nike.Business.BusinessLogic
{
    public static class ProductBL
    {
        #region Public Members

        //Get a list of {Product Category View Model}
        public static List<ProductCategoryVM> GetProducts()
        {
            //Instance of productMapper
            ProductMapper _productMapper = new ProductMapper();
            //List of products
            var productList = _productMapper.GetProducts();
            //List of View model for Products
            var productVMList = new List<ProductCategoryVM>();

            foreach (var item in productList)
            {
                var prod = new ProductCategoryVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Category = _productMapper.GetProductCategory(item)
                };

                productVMList.Add(prod);
            }

            return productVMList;

        }

        //Get the ProductCategory View Model with id = {id}
        public static ProductCategoryVM GetProduct(int id)
        {
            var _productMapper = new ProductMapper();
            var searchedProduct = _productMapper.GetProduct(id);

            if (searchedProduct != null)
            {
                var prodVM = new ProductCategoryVM
                {
                    Id = searchedProduct.Id,
                    Name = searchedProduct.Name,
                    Description = searchedProduct.Description,
                    Price = searchedProduct.Price,
                    Category = _productMapper.GetProductCategory(searchedProduct)
                };

                return prodVM;
            }

            return null;
        }
        #endregion
    }
}
