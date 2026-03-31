using ECommerceInfrastructure.Data;
using ECommerceInfrastructure.Data.Repositories;
using Microsoft.OpenApi.Models;
using ECommerceApplication.Feature.UseCases;
using ECommerceApplication.Feature.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerce API", Version = "v1" });
});

// Usa a key "SqlServer" definida em appsettings.json
var connectionString = builder.Configuration.GetConnectionString("SqlServer");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Connection string 'SqlServer' não encontrada. Verifique o appsettings.json ou a variável de ambiente.");
}

builder.Services.AddScoped(sp => new DbSession(connectionString));

// Repositório e UseCase
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<PostUsuarioUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce API v1"));
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
