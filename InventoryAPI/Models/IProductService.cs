using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Models;

public interface IProductService {
    public Task<ActionResult<IEnumerable<Product>>> GetProducts();
    public Task PostProduct(Product product);
    public Task<ActionResult<Product>> GetProduct(int id);
    public Task PutProduct(int id, Product product);
    public Task DeleteProduct(Product product);
    public bool ProductExists(int id);
}