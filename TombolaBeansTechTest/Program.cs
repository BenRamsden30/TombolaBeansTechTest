using TombolaBeansTechTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Blazor Services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<CoffeeBeanService>();

var app = builder.Build();

// Configure Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

// Ensure proper routing to Blazor UI
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");  // Make sure _Host.cshtml exists in Pages/

app.Run();