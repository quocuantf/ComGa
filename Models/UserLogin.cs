using System.ComponentModel.DataAnnotations;
namespace ComGa.Models {
    public class UserLogin {
        [Required]
        public string? Username {get; set;}
        [Required]
        public string? Password {get; set;}
        [Required]
        public bool RememberMe {get; set;}
    }
}