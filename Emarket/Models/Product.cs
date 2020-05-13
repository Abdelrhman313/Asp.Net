using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Emarket.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "You have to Enter A Title Of The Atrical")]
        public string ProductName { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "You have to Enter A Price Of The Product")]
        public int ProductPrice { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 200, ErrorMessage = "You have to Enter A Description Of The Product")]
        [Display(Name = "Product Description")]
        public string ProductDesc { get; set; }

        [FileExtensions(Extensions = "jpg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Cart Cart { get; set; }

        public static implicit operator Product(List<Product> v)
        {
            throw new NotImplementedException();
        }
    }
}