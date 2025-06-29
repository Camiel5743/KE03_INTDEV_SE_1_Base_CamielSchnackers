
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

public class CartModel : PageModel
{
    public List<CartItem> CartItems { get; set; } = new();

    private readonly IProductRepository _productRepository;

    public CartModel(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void OnGet(int productId = 0, int quantity = 1)
    {
        LoadCart();

        if (productId > 0)
        {
            var product = _productRepository.GetAllProducts().FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                var existing = CartItems.FirstOrDefault(c => c.Product.Id == productId);
                if (existing != null)
                    existing.Quantity += quantity;
                else
                    CartItems.Add(new CartItem { Product = product, Quantity = quantity });

                SaveCart();
            }
        }
    }

    public IActionResult OnPostIncreaseQuantity(int productId)
    {
        LoadCart();
        var item = CartItems.FirstOrDefault(c => c.Product.Id == productId);
        if (item != null) item.Quantity++;
        SaveCart();
        return RedirectToPage();
    }

    public IActionResult OnPostDecreaseQuantity(int productId)
    {
        LoadCart();
        var item = CartItems.FirstOrDefault(c => c.Product.Id == productId);
        if (item != null && item.Quantity > 1) item.Quantity--;
        SaveCart();
        return RedirectToPage();
    }

    public IActionResult OnPostRemoveItem(int productId)
    {
        LoadCart();
        CartItems.RemoveAll(c => c.Product.Id == productId);
        SaveCart();
        return RedirectToPage();
    }

    private void LoadCart()
    {
        var json = HttpContext.Session.GetString("Cart");
        if (json != null)
            CartItems = JsonSerializer.Deserialize<List<CartItem>>(json);
    }

    private void SaveCart()
    {
        var json = JsonSerializer.Serialize(CartItems);
        HttpContext.Session.SetString("Cart", json);
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
