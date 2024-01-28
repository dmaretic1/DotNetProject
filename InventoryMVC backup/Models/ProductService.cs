using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryMVC.Data;
using InventoryMVC.Models;

namespace InventoryMVC.Models;

public class ProductService : IProductService
{
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Index()
        {
            return await _context.Product.ToListAsync();
        }
        public async Task<List<Product>> FilterTest()
        {
            return await _context.Product.Where(p => !p.Name.ToLower().Contains("test")).ToListAsync();
        }
        public async Task<List<Product>> FilterAvailable()
        {
            return await _context.Product.Where(p => p.Available == true).ToListAsync();
        }

        public async Task<Product> Details(int? id)
        {
            return await _context.Product.FirstOrDefaultAsync(m => m.Id == id);;
        }

        public async Task<int> Create(Product product)
        {
                _context.Add(product);
                return await _context.SaveChangesAsync();
        }

        public async Task<Product> Edit(int? id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task<int> Edit(int id, Product product)
        {
                    _context.Update(product);
                    return await _context.SaveChangesAsync();
        }

        public async Task<Product> Delete(int? id)
        {
            return await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            return await _context.SaveChangesAsync();
        }

        public bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
}