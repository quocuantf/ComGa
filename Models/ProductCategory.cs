using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ComGa.Models {
    public class ProductCategory {
        [Key] [MaxLength(25)] [StringLength(25)]
        public string? CateGoryID {get; set;}
        [Required]
        public string? CateoryName{get; set;}
        //=== Navigator property ===
        public ICollection<Product>? Products{get; set;}
    }
}