using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ComGa.Models {
    public class Cart {
        [Key]
        [Required] [ForeignKey("UserID")]
        public string? UserID {get; set;}
        [ForeignKey("ProductID")]
        public string? ProductID{get; set;}
        // public ICollection<Product>? Products{get; set;}

    }
}