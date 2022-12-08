using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComGa.Models
{
    public class Order {
        [Key] [MaxLength(25)] [StringLength(25)]
        public String? OrderID {get; set;}
        [Required] [ForeignKey("UserID")]
        public String? UserID {get; set;}
        [Required]
        public DateTime OrderDate {get; set;}
        [Required]
        public string? Status {get; set;}
        // Navigator property
        // public ICollection<Product>? Products {get; set;}
        public ICollection<OrderDetail>? OrderDetails {get; set;}
    }
}