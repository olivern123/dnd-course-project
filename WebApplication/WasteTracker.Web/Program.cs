using WasteTracker.Web;
using WasteTracker.Web.Services;
using WasteTracker.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register HttpClient and your API service
builder.Services.AddHttpClient<WasteService>(client =>
{
    // NOTE: Change this to match your actual API base URL/port
    client.BaseAddress = new Uri("https://localhost:5104/api/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts(); // Default: 30 days
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForErrors: true);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
