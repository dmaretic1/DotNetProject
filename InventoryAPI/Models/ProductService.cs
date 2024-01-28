
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Models;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
        {
            _context = context;
        }
    public async Task DeleteProduct(Product product)
    {
        _context.Product.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        return await _context.Product.FindAsync(id);
    }


    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Product.ToListAsync();
    }

    public async Task PostProduct(Product product)
    {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
    }

    public async Task PutProduct(int id, Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public bool ProductExists(int id) {
        return _context.Product.Any(e => e.Id == id);
    }
}