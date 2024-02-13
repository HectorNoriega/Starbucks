using MediatR;
using Microsoft.EntityFrameworkCore;
using Starbucks.Application;
using Starbucks.Application.Behaviors;
using Starbucks.Domain.Abstractions;
using Starbucks.Domain.Repositories;
using Starbucks.Infraestructure;
using Starbucks.Infrastructure;
using Starbucks.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("StarbucksDB"));

builder.Services.AddScoped<IUnitOfWork>(
factory => factory.GetRequiredService<ApplicationDbContext>());

builder.Services.AddApplication().AddInfrastructure();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductReceiptRepository, ProductReceiptRepository>();
builder.Services.AddScoped<IMaterialStockRepository, MaterialStockRepository>();
builder.Services.AddScoped<IMaterialsRepository, MaterialsRepository>();
//Initialize DataBases

var _productRepository = builder.Services.BuildServiceProvider().GetService<IProductRepository>();
_productRepository?.InitProductsInMemoryDb();

var _receiptRepository = builder.Services.BuildServiceProvider().GetService<IProductReceiptRepository>();
_receiptRepository?.InitProductsInMemoryDb();

var _materialRepository = builder.Services.BuildServiceProvider().GetService<IMaterialsRepository>();
_materialRepository?.InitProductsInMemoryDb();

var _materialStockRepository = builder.Services.BuildServiceProvider().GetService<IMaterialStockRepository>();
_materialStockRepository?.InitProductsInMemoryDb();

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

app.Run();
