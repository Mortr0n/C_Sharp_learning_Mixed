using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
// Add services to the container.
builder.Services.AddControllersWithViews();
//TODO: Check here if we have DB troubles. This I had to figure out. This line is Erroring!!!
builder.Services.AddDbContext<CRUDeliciousContext>(options => options.UseMySql("DBInfo:ConnectionString"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseMvc();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
