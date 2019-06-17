using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "商品名称") ]
        [Required]
        public string Title { get; set; }

        [Display(Name = "详细信息")]
        public string Description { get; set; }

        
        [Required]
        [Display(Name = "价格")]
        public decimal  Price { get; set; }

        [Display(Name = "图片")]
        public string ImageUrl { get; set; }


    }
}