using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using DataAccessLayer.Interfaces;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public CheckoutModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [BindProperty(SupportsGet = true)]
        public int ProductId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Quantity { get; set; } = 1;

        public Product? Product { get; set; }

        public void OnGet()
        {
            Product = _productRepository.GetProductById(ProductId);
        }

        public void OnPost()
        {
            Product = _productRepository.GetProductById(ProductId);
        }
    }
}
