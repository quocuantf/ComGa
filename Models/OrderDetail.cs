using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ComGa.Models {
    // [Microsoft.EntityFrameworkCore.Keyless]
    public class OrderDetail {
        [Key] [ForeignKey("OrderID")] [Required] [MaxLength(25)] [StringLength(25)]
        public string? OrderID {get; set;}
        [Key] [ForeignKey("ProductID")] [Required] [MaxLength(25)] [StringLength(25)]
        public String?  ProductID { get; set; }
        [Required]
        public int Quantity {get; set;}
    }
}