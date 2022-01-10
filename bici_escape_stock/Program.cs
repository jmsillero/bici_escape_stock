using bici_escape_stock.Data.repository;
using bici_escape_stock.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BEscapeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});


builder.Services.AddScoped<CurrencyRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<EntryRepository>();
builder.Services.AddScoped<InventoryRepository>();
builder.Services.AddScoped<SalesRepository>();
builder.Services.AddScoped<PaymentRepository>();

builder.Services.AddScoped<VendorRepository>();
builder.Services.AddScoped<VendorEntryRepository>();
builder.Services.AddScoped<VendorPaymentRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();