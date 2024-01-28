
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryMVC.Data;
using InventoryMVC.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace InventoryMVC.Models;

public class PurchaseService : IPurchaseService
{
        private readonly ApplicationDbContext _context;

        public PurchaseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Purchase>> Index()
        {
            var applicationDbContext = _context.Purchase.Include(p => p.Product);
            return await applicationDbContext.ToListAsync();
        }

        public async Task<List<Purchase>> FilterTest()
        {
            return await _context.Purchase.Include(p => p.Product).Where(p => !p.BuyerName.ToLower().Contains("test")).ToListAsync();
        }

        public async Task<List<Purchase>> FilterProduct()
        {
            return await _context.Purchase.Include(p => p.Product).Where(p => !p.Product.Name.ToLower().Contains("test")).ToListAsync();
        }

        public async Task<Purchase> Details(int? id)
        {
            return await _context.Purchase
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public SelectList Create()
        {
            return new SelectList(_context.Product, "Id", "Name");
        }

        public async Task<int> Create([Bind("BuyerName,ProductId")] Purchase purchase)
        {
            _context.Add(purchase);
            return await _context.SaveChangesAsync();
        }

        public async Task<Purchase> Edit(int? id)
        {
            return await _context.Purchase.FindAsync(id);
        }

        public async Task<SelectList> SelectList(Purchase purchase) {
            return new SelectList(_context.Product, "Id", "Name", purchase.ProductId);
        }

        public async Task<int> Edit(int id, [Bind("Id,BuyerName,ProductId")] Purchase purchase)
        {
                 _context.Update(purchase);
                return await _context.SaveChangesAsync();
        }

        public async Task<Purchase> Delete(int? id)
        {
            return await _context.Purchase
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> DeleteConfirmed(int id)
        {
            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase != null)
            {
                _context.Purchase.Remove(purchase);
            }
            return await _context.SaveChangesAsync();
        }

        public bool PurchaseExists(int id)
        {
            return _context.Purchase.Any(e => e.Id == id);
        }
    }