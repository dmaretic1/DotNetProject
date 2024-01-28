using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Models;

public interface IPurchaseService {
    public Task<ActionResult<IEnumerable<Purchase>>> GetPurchases();
    public Task<ActionResult<IEnumerable<Purchase>>> GetPurchases(string name);
    public Task PostPurchase(Purchase purchase);
    public Task<ActionResult<Purchase>> GetPurchase(int id);
    public Task PutPurchase(int id, Purchase purchase);
    public Task DeletePurchase(Purchase purchase);
    public bool PurchaseExists(int id);
}