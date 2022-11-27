using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComGa.Data {
    public class ComGaContext : IdentityDbContext<IdentityUser>  {
        public ComGaContext(DbContextOptions<ComGaContext> options) : base(options) {

        }
    
        // [PersonalData] --> using for personal data on db context;
    }
}