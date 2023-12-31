using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Northwind_API.Entities;
using Repository; // Assurez-vous que c'est le bon espace de noms pour votre IRepository et BaseRepository
using Northwind_API.Repositories;
using Northwind_API.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Ajout de la configuration du DbContext
builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindDatabase")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Configuration du repository pour l'injection de dépendances
builder.Services.AddScoped<IRepository<Employee>, BaseRepository<Employee>>();
builder.Services.AddScoped<EmployeeRepository>();

// Configuration de Swagger pour générer une documentation API et une interface utilisateur
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ajout des services de contrôleurs
builder.Services.AddControllers();
    //.AddJsonOptions(options =>
      //  options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);

var app = builder.Build();

// Configuration du pipeline HTTP request
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Si vous n'utilisez pas l'autorisation/autentification, vous pouvez commenter la ligne suivante
// app.UseAuthorization();

app.MapControllers(); // Mappage des contrôleurs pour les routes

app.Run();
