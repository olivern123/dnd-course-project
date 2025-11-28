# Blog Post 2 - Web Service Design & Implementation
During this phase we have implemented the backbone for our ESG waste management system by creating a .NET 8 Web API with database support using SQLite and a controller for handling waste data. The goal was to create a clean RESTful Web API that our blazor frontend can interact using HTTP requests. To achieve this, we built a .NET 8 web api that exposes endpoints for handling waste entries, sites, waste types, as well as userlogin and authentication.

## Setting up the Web API
The API is built using .net 8 Entity Framework Core and SQLite as our data storage. SQLite was chosen because it provides a simple file-based database (waste.db) that fits the scope of this project. In the program.cs in the web api, we configure EF Core and register our controllers:

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

Enabling Swagger ensures that we can interact with our API endpoints and test during development.
When running in development, the API exposes Swagger UI:
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

## Waste Entry API Design
The main part of our system is the WasteMangementController.cs, which exposes the main REST endpoints for the waste tracking function. Using EF Core, the controller uses the same related entities when retrieving data so that the frontend recieves complete objects:

[HttpGet]
public async Task<ActionResult<IEnumerable<WasteEntry>>> GetWasteEntries()
{
    return await _context.WasteEntries
        .Include(w => w.Site)
        .Include(w => w.WasteType)
        .Include(w => w.HandlingMethod)
        .ToListAsync();
}

Posting waste data happens here:

[HttpPost]
public async Task<ActionResult<WasteEntry>> PostWasteEntry(WasteEntry entry)
{
    _context.WasteEntries.Add(entry);
    await _context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetWasteEntry), new { id = entry.EntryId }, entry);
}

This structure gives us a clean REST interface:

GET /api/wasteentries – return all entries

GET /api/wasteentries/{id} – return a single entry

POST /api/wasteentries – insert a new entry
