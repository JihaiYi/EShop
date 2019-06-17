using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EShop.Models
{
    public class Cart
    {

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection <CartItem> CartItems { get; set; }

    }
}