using HealthTrak.Server.Context;
using HealthTrak.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<HealthTrakDbDontext>(
    options => options.UseInMemoryDatabase("HealthTrakDb")
    );

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<HealthTrakDbDontext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapIdentityApi<IdentityUser>();

app.MapControllers();

app.MapGet("/food", (HttpContext httpContext) =>
{
    var meal = new Food
    {
        calories = 100,
        protein = 2,
        carbs = 4,
        fats = 5
    };
    return meal;
})
.WithName("GetWeatherForecast")
.RequireAuthorization();

app.Run();
