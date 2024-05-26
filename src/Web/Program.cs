using Facturador.Application.Common.Interfaces;
using Facturador.Web.Entities;
using Facturador.Web.Models;
using Facturador.Web.Reverse;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add Authentication
builder.Services.AddAuthentication();

// Add Authorization
builder.Services.AddAuthorizationBuilder();

// Configure DbContext 
builder.Services.AddDbContext<InvoiceContext>(
    options => options.UseSqlServer("name=ConnectionStrings:Invoice"));

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<InvoiceContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
    //.RequireAuthorization();

app.Run();
