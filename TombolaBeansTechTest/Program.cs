using TombolaBeansTechTest.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add services to the dependency injection container
builder.Services.AddRazorPages();  // Enables Razor Pages
builder.Services.AddServerSideBlazor();  // Enables Blazor Server
builder.Services.AddSingleton<CoffeeBeanService>(); // Inject CoffeeBeanService

var app = builder.Build();

// ✅ Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// ✅ Serve static files (needed for loading JSON from wwwroot)
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host"); // Routes to Blazor UI

app.Run();