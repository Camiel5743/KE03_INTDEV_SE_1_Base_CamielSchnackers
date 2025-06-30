using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

public class OrderHistoryModel : PageModel
{
    private readonly MatrixIncDbContext _context;

    public OrderHistoryModel(MatrixIncDbContext context)
    {
        _context = context;
    }

    public List<OrderViewModel> Orders { get; set; }

    public void OnGet()
    {
        Orders = _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Products)
            .Select(o => new OrderViewModel
            {
                Id = o.Id,
                Customer = o.Customer.Naam + " " + o.Customer.Achternaam,
                Date = o.OrderDate,
                Products = o.Products.Select(p => new ProductViewModel
                {
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            })
            .ToList();
    }

    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public System.DateTime Date { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }

    public class ProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
