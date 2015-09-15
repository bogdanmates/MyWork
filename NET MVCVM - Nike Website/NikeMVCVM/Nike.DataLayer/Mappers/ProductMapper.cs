using Nike.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nike.DataLayer.Mappers
{
    public class ProductMapper
    {
        #region Public Members
        //Get all products
        public List<Nike.DataLayer.Nike_Product> GetProducts()
        {
            using (var db = new NikeDBEntities())
            {
                var products = db.Nike_Product.ToList();

                return products;
            }
        }

        //Get product with id = {id}
        public Nike_Product GetProduct(int id)
        {
            using (var db = new NikeDBEntities())
            {
                var prod = db.Nike_Product.FirstOrDefault(p => p.Id == id);

                return prod;
            }
        }

        //Get category of the product {prod}
        public string GetProductCategory(Nike_Product prod)
        {
            using (var db = new NikeDBEntities())
            {
                var category = db.Nike_Category.FirstOrDefault(p => p.Id == prod.CategoryId);

                return category.Name;
            }
        } 

        #endregion
    }
}
