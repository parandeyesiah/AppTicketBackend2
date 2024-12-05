using AppTicketV2.EF.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
Console.WriteLine("Configuration Paths:");
//var options = builder.Configuration.config
//foreach (var provider in builder.Configuration.Pro) { Console.WriteLine(provider); }
string? cs = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<AppTicketDBContext>(options =>
    options.UseSqlServer(cs));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(-1);
        /*c.EnableJsonEditor(false); // Disable JSON editor
        c.EnableTryItOut(false); // Disable "Try it out" button
        c.EnableDeepLinking(false); // Disable deep linking
        c.EnableSyntaxHighlighting(false); // Disable syntax highlighting*/
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // This will make Swagger available at the root URL.
    });

}

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(name: "default", pattern: "api/{controller=Home}/{action=Index}/{id?}");
app.UseStaticFiles();
app.Run();
