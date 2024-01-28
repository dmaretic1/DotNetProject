using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryMVC.Models;

public interface IPurchaseService {
public  Task<List<Purchase>> Index();

        public Task<List<Purchase>> FilterTest();

        public Task<List<Purchase>> FilterProduct();

        // GET: Purchases/Details/5
        public  Task<Purchase> Details(int? id);

        // GET: Purchases/Create
        public SelectList Create();
        public  Task<int> Create(Purchase purchase);

        // GET: Purchases/Edit/5
        public Task<Purchase> Edit(int? id);

        public Task<SelectList> SelectList(Purchase purchase);
        public Task<int> Edit(int id, Purchase purchase);

        public Task<Purchase> Delete(int? id);
        public Task<int> DeleteConfirmed(int id);

        public bool PurchaseExists(int id);
}