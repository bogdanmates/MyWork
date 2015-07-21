using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nike.DataLayer.Models
{
    class ShoppingCart
    {
        public int Id { get; set; }
      // public List<Product> Items { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
