using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Emarket.Models;

namespace Emarket.Models
{
    public class Cart
    {   
        
        [Display(Name ="Added_Time")]
        public System.DateTime added_at { get; set; }

        [Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        
    }
}