using Nike.Business.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikeMVCVM.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            var products = ProductBL.GetProducts();
            
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = ProductBL.GetProduct(id);
            
            return View(product);
        }
    }
}
