using Microsoft.EntityFrameworkCore;
using pruebaTecnica.Models;
using pruebaTecnica.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ProductClientContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnPruebaDb")));


//TrustServerCertificate = True;
//builder.Services.AddSqlServer<ProductClientContext>(builder.Configuration.GetConnectionString("cnPruebaDb"));

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IHomeService, HomeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();


//Data  Source = ; Initial Catalog = pruebaTecnicaDb; user id = sa; password=1234; TrustServerCertificate = True
//Scaffold-DbContext "Server=DESKTOP-MUVRQ2S;Database=prueba;user id = sa; password=1234;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models