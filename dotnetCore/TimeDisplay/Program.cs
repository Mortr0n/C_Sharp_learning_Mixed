var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
var app = builder.Build();

app.UseMvc();
IWebHostEnvironment env = app.Environment;

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}



app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");

app.Run();
