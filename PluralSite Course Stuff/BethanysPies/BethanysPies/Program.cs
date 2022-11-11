using BethanysPies.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

//Adding framework services that enable MVC
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BethanysPiesDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BethanysPiesDbContextConnection"]);
});

//After app has been called we can then use the app instance to bring in middleware components
var app = builder.Build();

//adding ability to bring in static files. And will look in wwwroot and return the static files
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// will set default routes to route to the views that we will have.  Endpoint Middleware!
app.MapDefaultControllerRoute();
DbInitializer.Seed(app);
app.Run();