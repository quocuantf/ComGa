using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using ComGa.Models;
using ComGa.Repository;
using ComGa.Data;
using Microsoft.AspNetCore.Identity;

namespace ComGa.Controllers {
    public class ProductController : Controller {
        // private int pageSize = 5;
        private readonly ComGaContext _context;
        private readonly IProductRepository _productRep;
        private readonly IProductCategoryReposity _productCategoryRep;
        private readonly UserManager<User> _userManager;
        public ProductController(IProductRepository productRepo,
                IProductCategoryReposity productCategoryRep,
                ComGaContext context, UserManager<User> userManager) {
            _productRep = productRepo; 
            _productCategoryRep = productCategoryRep;
            _context = context;
            _userManager = userManager;
        }
        
        //Get product
        public async Task<IActionResult> index(int? pageNumber,string categoryID) {
            IEnumerable<Product> products;
            if (categoryID == null) {
                products = _productRep.getAll();
            } else {
                products = await _productRep.getByCategory(categoryID);
            }
            ViewBag.categorys =  _productCategoryRep.getAll();
            int _pageNumber = (pageNumber ?? 1);
            ViewBag.CurrentPageNumber = _pageNumber;
            return View("Index", products);
        }

        //Get product by category
        public async Task<IActionResult> getByCategory(string categoryID) {            
            ViewBag.categorys =  _productCategoryRep.getAll();
            
            if (categoryID == null) {
                return NotFound();
            }
            else {
                var products = await _productRep.getByCategory(categoryID);
                return View("Index",products);
            }
        }

        //Get product detail
        public  IActionResult details(string id) {
            var result = _productRep.getFullDetail(id);
            if (result != null){
                return View(result);
            } else {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult addToCart(Product product) {
            
            // _context.Carts.Add
            // string userID = HttpContext.User.
            var user = _userManager.GetUserAsync(HttpContext.User);
            
            var id = user.Id;
            Cart cart = new  Cart{
                UserID = _userManager.GetUserId(HttpContext.User),
                ProductID = product.ProductID.ToString(),
            };
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return View("Product");
        }

    }
}