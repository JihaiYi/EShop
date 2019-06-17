using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "商品数量")]

        public int ProductCount { get; set; }

        public int CartId { get; set; }

        [ForeignKey ("CartId")]
        public Cart Cart { get; set; }


        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}