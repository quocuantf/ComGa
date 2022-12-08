using ComGa.Data;
using ComGa.Models;
using Microsoft.EntityFrameworkCore;
namespace ComGa.Repository {
    public class ProductRepository : GenericRepository<Product>,IProductRepository {
        private readonly ComGaContext _conetxt;
        // public ProductRepository(ComGaContext context) {
        //     _conetxt = context;
        // } 
        // private readonly ComGaContext _context;
        public ProductRepository(ComGaContext context) : base(context) {
            _conetxt = context;
        }
        // public ProductRepository(ComGaContext context) {
        //     _conetxt = context;
        // }
        public async Task<IEnumerable<Product>> getByCategory(string cateGoryID) {
            var res = await _conetxt.Products.Where(p => p.ProductCategoryID == cateGoryID)
                .ToListAsync();
            return res;
        }
        public Product? getFullDetail(string ProductID) {
            var res = _conetxt.Products
                .Include(p => p.Photos)
                .FirstOrDefault(p => p.ProductID.ToString() == ProductID);
            return (res);
        }
    }
}