# Blog post 5 Data access
## ORM
Using ORM we no longer had to write and SQL manually. We can focus our work with C# objects rather than tables in SQL, as it is done automatically for us using this framework.
The core piece is the Appdbcontext.db, which represents our database and defines our tables:

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<WasteEntry> WasteEntries => Set<WasteEntry>();
    public DbSet<Site> Sites => Set<Site>();
    public DbSet<WasteType> WasteTypes => Set<WasteType>();
    public DbSet<HandlingMethod> HandlingMethods => Set<HandlingMethod>();
    public DbSet<User> Users => Set<User>();
}
This tells EFC to create tables inside waste.db
## Refactoring the API to use EFC
Before using EFC, inserting, retrieving or deleting data would have required either SQL queries or manual parsing of files. After applying the ORM, our controllers have become much simpler. For example, adding a new waste entry is now only:
_context.WasteEntries.Add(entry);
await _context.SaveChangesAsync();
and fetching all entries is a sinle LINQ expression:
_context.WasteEntries
    .Include(w => w.Site)
    .Include(w => w.WasteType)
    .Include(w => w.HandlingMethod)
    .ToListAsync();
Without this, this would have required manually writing SQL joins. 
## Linq vs SQL
LINQ (Language Integrated Query) lets us query the database directly using C# syntax.
For example, to fetch all entries for a specific site:
var result = await _context.WasteEntries
    .Where(w => w.SiteId == 1)
    .ToListAsync();

SQL Would have looked like this:
SELECT * 
FROM WasteEntries 
WHERE SiteId = 1;
With SQL, developers must manually write queries and parse the results.
With LINQ, the ORM translates C# expressions into SQL behind the scenes.
