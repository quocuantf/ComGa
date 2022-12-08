using System;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ComGa.Models;
using ComGa.Data;

namespace ComGa.Repository {
    public interface IProductRepository : IGenericReposity<Product> {
        public Task<IEnumerable<Product>> getByCategory(string categoryID);
        public Product? getFullDetail(string ProductID);
    }
}