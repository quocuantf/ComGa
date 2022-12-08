using Microsoft.AspNetCore.Identity;
namespace ComGa.Models {
    public class User : IdentityUser{
        [PersonalData]
        public string? FirstName;
        [PersonalData]
        public string? LastName;
        public Cart? Carts{get; set;}
        public ICollection<Order>? Orders {get; set;}
    } 
}