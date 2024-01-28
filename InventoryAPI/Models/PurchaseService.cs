
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Models;

public class PurchaseService : IPurchaseService
{
    private readonly AppDbContext _context;

    public PurchaseService(AppDbContext context)
        {
            _context = context;
        }

    public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases()
    {
        return await _context.Purchase.ToListAsync();
    }

    public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases(string name)
    {
        return await _context.Purchase.Where(p => p.BuyerName.Contains(name)).ToListAsync();
    }

    public async Task<ActionResult<Purchase>> GetPurchase(int id)
    {
        return await _context.Purchase.FindAsync(id);
    }

    public async Task PostPurchase(Purchase purchase)
    {
        _context.Purchase.Add(purchase);
        await _context.SaveChangesAsync();
    }

    public async Task PutPurchase(int id, Purchase purchase)
    {
        _context.Entry(purchase).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeletePurchase(Purchase purchase)
    {
        _context.Purchase.Remove(purchase);
        await _context.SaveChangesAsync();
    }

    public bool PurchaseExists(int id) {
        return _context.Purchase.Any(e => e.Id == id);
    }
}