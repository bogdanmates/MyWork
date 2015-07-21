using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Nike.Business.ViewModels.Product
{
    public class ProductCartVM
    {
        #region Properties
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public int Quantity { get; set; }
        #endregion
    }
}
