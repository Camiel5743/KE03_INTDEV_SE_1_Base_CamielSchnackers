using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages;
public class ProductCatalogModel : PageModel
{
    private readonly IProductRepository _productRepository;

    public ProductCatalogModel(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> Products { get; set; }

    public void OnGet()
    {
        Products = _productRepository.GetAllProducts().ToList();
    }
}

