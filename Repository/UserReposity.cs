using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using ComGa.Models;
using ComGa.Data;

namespace ComGa.Repository {
    public class UserReposity : IUserReposity {
        private readonly ComGaContext _context;
        private string? _UserID {get; set;}
        public UserReposity(IHttpContextAccessor httpContextAccessor, UserManager<Models.User> userManager) {
            if (httpContextAccessor.HttpContext != null) {
                // var user = userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
                var u = userManager.GetUserId(httpContextAccessor.HttpContext.User);
                // _UserID = user.Id.ToString();
                _UserID = u;
            } 
            else {
                _UserID = null;
            }
        }
        public void saveChange() {
            if (_UserID != null) {
                _context.SaveChanges();
            } 
            else {
                return;
            }
        }

        public string getUserID() {
            return _UserID;
        }

        public void addToCart(Product product) {
            Cart cart = new Cart{
                UserID = _UserID,
                ProductID = product.ProductID.ToString(),
            };
        }
    }
}