using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComGa.Models {

    public class Photo {
        [Key]
        public string? PhotoId { get; set; }
        [Required]
        public string? ImgPath {get; set;}
        public string? Description { get; set; }
        [Required] [ForeignKey("ProductID")]
        public string? ProductID;
    }
}
