using Facturador.Application.Common.Interfaces;
using Facturador.Web.Models;
using Facturador.Web.Reverse;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// Add Authentication
builder.Services.AddAuthentication().AddBearerToken();

// Add Authorization
builder.Services.AddAuthorization();

// Configure DbContext 
builder.Services.AddDbContext<InvoiceContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Invoice")));

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<InvoiceContext>()
    .AddApiEndpoints();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapIdentityApi<User>();

app.MapControllers();


app.Run();
