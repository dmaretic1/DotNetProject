using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryMVC.Models;

namespace InventoryRazerPages.Pages_Products
{
    public class IndexSortedModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexSortedModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Product.OrderBy(t => t.Name).ToListAsync();
        }
    }
}
