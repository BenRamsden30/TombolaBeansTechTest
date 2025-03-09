using TombolaBeansTechTest.Pages;

var builder = WebApplication.CreateBuilder(args);

// Register Blazor and Pages
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register CoffeeBeanService
builder.Services.AddSingleton<CoffeeBeanService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Ensure static files are accessible
app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();