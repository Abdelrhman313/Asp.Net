using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emarket.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Number Of Product")]
        public int NumberOfProduct { get; set; }

    }
}