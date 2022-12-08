using ComGa.Models;
using ComGa.Data;
using Microsoft.EntityFrameworkCore;

namespace ComGa.Repository {
    class ProductCategoryReposity : GenericRepository<ProductCategory>, IProductCategoryReposity {
        private readonly ComGaContext _context;

        public ProductCategoryReposity(ComGaContext context) : base(context) {
            _context = context;
        }
    }
}