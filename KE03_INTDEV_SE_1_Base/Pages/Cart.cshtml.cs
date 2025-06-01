using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class CartModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int ProductId { get; set; }

    [BindProperty(SupportsGet = true)]
    public int Quantity { get; set; } = 1;

    public List<CartItem> CartItems { get; set; } = new();

    private readonly IProductRepository _productRepository;

    public CartModel(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void OnGet()
    {
        if (ProductId > 0)
        {
            var product = _productRepository.GetAllProducts().FirstOrDefault(p => p.Id == ProductId);
            if (product != null)
            {
                CartItems.Add(new CartItem
                {
                    Product = product,
                    Quantity = Quantity
                });
            }
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
