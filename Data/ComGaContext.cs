using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ComGa.Models;

namespace ComGa.Data {
    public class ComGaContext : IdentityDbContext<User>  {
        //Inject sql connection to database context
        public ComGaContext(DbContextOptions<ComGaContext> options) : base(options) {

        }

        public DbSet<ComGa.Models.ProductCategory> ProductCategories { get; set; } = default!;
        public DbSet<ComGa.Models.Product> Products { get; set; } = default!;
        public DbSet<ComGa.Models.Photo> Photos { get; set; } = default!;
        public DbSet<ComGa.Models.Order> Orders { get; set; } = default!;
        public DbSet<ComGa.Models.OrderDetail> OrderDetails { get; set; } = default!;
        public DbSet<Cart> Carts {get; set;} = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetail>()
                .HasKey(p => new { p.OrderID, p.ProductID });
            modelBuilder.Entity<Product>(
                p => {
                    p.Property("ProductID")
                        .HasDefaultValueSql("newsequentialid()");
                }
            );
        }
        // [PersonalData] --> using for personal data on db context;
    }
}