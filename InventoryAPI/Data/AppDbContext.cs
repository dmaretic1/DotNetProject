using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<InventoryAPI.Models.Product> Product { get; set; } = default!;

public DbSet<InventoryAPI.Models.Purchase> Purchase { get; set; } = default!;
    }
