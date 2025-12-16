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
    public DbSet<User> Users => Set<User>();
    public DbSet<UploadedFile> UploadedFiles => Set<UploadedFile>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<Site>().HasKey(s => s.SiteId);
            modelBuilder.Entity<WasteType>().HasKey(w => w.WasteTypeId);
            modelBuilder.Entity<HandlingMethod>().HasKey(h => h.HandlingId);
            modelBuilder.Entity<WasteEntry>().HasKey(e => e.EntryId);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<UploadedFile>().HasKey(f => f.Id);

        modelBuilder.Entity<UploadedFile>()
            .HasOne(f => f.WasteEntry)
            .WithMany()                          // WasteEntry can have many files
            .HasForeignKey(f => f.WasteEntryId)
            .OnDelete(DeleteBehavior.Cascade);


        // Sites
        modelBuilder.Entity<Site>().HasData(
            new Site { SiteId = 1, Name = "Convert", Location = "Denmark" },
            new Site { SiteId = 2, Name = "Innvik", Location = "Norway" }
        );

        // Waste types
        modelBuilder.Entity<WasteType>().HasData(
            new WasteType { WasteTypeId = 1, Name = "Yarn leftovers", Category = "Fiber" },
            new WasteType { WasteTypeId = 2, Name = "Fabric scraps", Category = "Fabric" },
            new WasteType { WasteTypeId = 3, Name = "Packaging", Category = "Cardboard/Plastic" },
            new WasteType { WasteTypeId = 4, Name = "Kantspild", Category = "Edge waste" },
            new WasteType { WasteTypeId = 5, Name = "InternalReuse", Category = "Reused internally" }
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

        // Users Login
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin" },
            new User { Id = 2, Username = "user", Password = "user123", Role = "User" }
        );
    }
}
