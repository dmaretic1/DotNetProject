using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace InventoryAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchasesController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        // GET: api/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchase()
        {
            return await _purchaseService.GetPurchases();
        }

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id)
        {
            var purchase = await _purchaseService.GetPurchase(id);

            if (purchase == null)
            {
                return NotFound();
            }

            return purchase;
        }

        [HttpGet("sorting/{name}")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases(string name)
        {
            var purchases = await _purchaseService.GetPurchases(name);

            if (purchases.Value.IsNullOrEmpty())
            {
                return NotFound();
            }

            return purchases;
        }

        // PUT: api/Purchases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase(int id, Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return BadRequest();
            }

            try
            {
                await _purchaseService.PutPurchase(id, purchase);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Purchases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
        {
            await _purchaseService.PostPurchase(purchase);

            return CreatedAtAction("GetPurchase", new { id = purchase.Id }, purchase);
        }

        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var purchase = await _purchaseService.GetPurchase(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _purchaseService.DeletePurchase(purchase.Value);

            return NoContent();
        }

        private bool PurchaseExists(int id)
        {
            return _purchaseService.PurchaseExists(id);
        }
    }
}
