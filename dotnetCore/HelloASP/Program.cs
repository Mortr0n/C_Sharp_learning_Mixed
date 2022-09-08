var builder = WebApplication.CreateBuilder(args);
// Adding services is more like node in ASP.net Core 6
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
var app = builder.Build();
// Adding services is more like node in ASP.net Core 6
app.UseMvc();
IWebHostEnvironment env = app.Environment;
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}



app.MapGet("/", () => "Hello World + 4 and Tacos!");

// app.MapGet("/", () => 
// {
//     Console.WriteLine(env.ContentRootPath);
//     Console.WriteLine(env.IsDevelopment());
    
// });

app.Run();
