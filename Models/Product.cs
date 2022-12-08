using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ComGa.Models
{
    public class Product {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] [MaxLength(25)] [StringLength(25)]
        public Guid ProductID { get; set; }
        [ForeignKey("ProductCategoryID")]
        public string? ProductCategoryID {get; set;}
        [Required] [MaxLength(250)] [StringLength(250)]
        public string? ProductName { get; set; }
        public string? Description {get; set;}
        [Required]
        public int? size { get; set; }
        [Required]
        public int? Price { get; set; }
        [Required]
        public DateTime? ManufactoringDate { get; set; }
        [Required]
        public string? ThumbnailPhotoPath {get; set;}

        //Navigation property: configure one-t0-many relationship with Photo 
        public ICollection<Photo>? Photos {get; set;}
        public ICollection<OrderDetail>? OrderDetails {get; set;}
        public ICollection<Cart>? Carts {get; set;}
    }
}