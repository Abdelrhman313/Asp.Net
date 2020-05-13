using Emarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emarket.ViewModel
{
    public class ProductCategories
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}