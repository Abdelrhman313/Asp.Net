using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emarket.Models;

namespace Emarket.ViewModel
{
    public class ProductCard
    {
        public Cart Cart { get; set; }
        public IEnumerable<Product> Product { get; set; }
    }
}