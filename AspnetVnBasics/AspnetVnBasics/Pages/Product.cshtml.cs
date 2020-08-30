using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetVnBasics.Entities;
using AspnetVnBasics.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetVnBasics.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;

        public ProductModel(
            IProductRepository productRepository,
            ICartRepository cartRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentException(nameof(IProductRepository));
            _cartRepository = cartRepository ?? throw new ArgumentException(nameof(ICartRepository));
        }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public Product ProductLast { get; set; } = new Product();

        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? categoryId)
        {
            Categories = await _productRepository.GetCategories();
            var products = await _productRepository.GetProducts();
            ProductLast = products.LastOrDefault();
            if (categoryId.HasValue)
            {
                Products = await _productRepository.GetProductByCategory(categoryId.Value);
                SelectedCategory = Categories.FirstOrDefault(c => c.Id == categoryId.Value)?.Name;
            }
            else
            {
                Products = await _productRepository.GetProducts();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _cartRepository.AddItem("test", productId);
            return RedirectToPage("Cart");
        }
    }
}