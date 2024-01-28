using Microsoft.AspNetCore.Mvc;

namespace InventoryMVC.Models;

public interface IProductService {
    public  Task<List<Product>> Index();
    public  Task<List<Product>> FilterTest();
    public  Task<List<Product>> FilterAvailable();
    public Task<Product> Details(int? id);

    public Task<int> Create(Product product);

    public Task<Product> Edit(int? id);

    public Task<int> Edit(int id, Product product);

    public Task<Product> Delete(int? id);

    public Task<int> DeleteConfirmed(int id);
    public bool ProductExists(int id);
}