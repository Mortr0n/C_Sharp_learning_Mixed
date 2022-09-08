var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
var app = builder.Build();
app.UseMvc();
IWebHostEnvironment env = app.Environment;
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () => "Hello World!");
// app.MapGet("/", () => {
//     Console.WriteLine(env.ContentRootPath);
//     Console.WriteLine(env.IsDevelopment());
// });

app.Run();
