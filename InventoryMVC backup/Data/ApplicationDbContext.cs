using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InventoryMVC.Models;

namespace InventoryMVC.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<InventoryMVC.Models.Product> Product { get; set; } = default!;

public DbSet<InventoryMVC.Models.Purchase> Purchase { get; set; } = default!;
}
