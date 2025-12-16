using WasteTracker.Web;
using WasteTracker.Web.Services;
using WasteTracker.Web.Components;
using Microsoft.AspNetCore.Http.Features;   // <-- REQUIRED for file upload size fix

var builder = WebApplication.CreateBuilder(args);

// ================================================
// Blazor Component Setup
// ================================================
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ================================================
// HttpClient – API Base URL
// ================================================
builder.Services.AddHttpClient("Default", client =>
{
    client.BaseAddress = new Uri("http://localhost:5104/api/");
});

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("Default"));

// Register your service
builder.Services.AddScoped<WasteService>();
builder.Services.AddScoped<AuthService>();

// ================================================
// FILE UPLOAD SIZE FIX (IMPORTANT FOR EXCEL FILES)
// ================================================
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 1024 * 1024 * 50; // 50MB upload limit
});

var app = builder.Build();

// ================================================
// Middleware
// ================================================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForErrors: true);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
