using Microsoft.EntityFrameworkCore;
using WasteManagement.API.Models;

namespace WasteManagement.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Site> Sites => Set<Site>();
    public DbSet<WasteType> WasteTypes => Set<WasteType>();
    public DbSet<HandlingMethod> HandlingMethods => Set<HandlingMethod>();
    public DbSet<WasteEntry> WasteEntries => Set<WasteEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Sites
        modelBuilder.Entity<Site>().HasData(
            new Site { SiteId = 1, Name = "Convert", Location = "Denmark" },
            new Site { SiteId = 2, Name = "Innvik", Location = "Norway" }
        );

        // Waste types
        modelBuilder.Entity<WasteType>().HasData(
            new WasteType { WasteTypeId = 1, Name = "Yarn leftovers", Category = "Fiber" },
            new WasteType { WasteTypeId = 2, Name = "Fabric scraps", Category = "Fabric" },
            new WasteType { WasteTypeId = 3, Name = "Packaging", Category = "Cardboard/Plastic" }
        );

        // Handling methods
        modelBuilder.Entity<HandlingMethod>().HasData(
            new HandlingMethod { HandlingId = 1, Method = "Incineration", CostPerTon = 150, CO2FactorPerTon = 2500 },
            new HandlingMethod { HandlingId = 2, Method = "Recycling", CostPerTon = 80, CO2FactorPerTon = 500 }
        );

        // Waste entries
        modelBuilder.Entity<WasteEntry>().HasData(
            new WasteEntry { EntryId = 1, SiteId = 1, WasteTypeId = 1, HandlingId = 1, QuantityKg = 200, Date = DateTime.Parse("2025-01-10") },
            new WasteEntry { EntryId = 2, SiteId = 1, WasteTypeId = 2, HandlingId = 2, QuantityKg = 150, Date = DateTime.Parse("2025-01-15") },
            new WasteEntry { EntryId = 3, SiteId = 2, WasteTypeId = 3, HandlingId = 1, QuantityKg = 300, Date = DateTime.Parse("2025-02-01") }
        );
    }
}
