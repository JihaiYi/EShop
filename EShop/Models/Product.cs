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
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal  Price { get; set; }

        public string ImageUrl { get; set; }


    }
}