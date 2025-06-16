using DataAccessLayer.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class OrderHistoryModel : PageModel
        {
            private readonly MatrixIncDbContext _context;

            public OrderHistoryModel(MatrixIncDbContext context)
            {
                _context = context;
            }

            public List<Order> Orders { get; set; }

            public void OnGet()
            {
                Orders = _context.Orders
                    .OrderByDescending(o => o.OrderDate)
                    .ToList();
            }
        }
    

}
   
