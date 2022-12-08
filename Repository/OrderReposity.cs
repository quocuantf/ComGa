using ComGa.Data;
using ComGa.Models;
namespace ComGa.Repository {
    public class OrderReposity : GenericRepository<Order>, IOrderReposity {
        public OrderReposity(ComGaContext context) : base(context) {
        }
    }
}