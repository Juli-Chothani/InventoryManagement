using InventoryAccounting.Core.Interfaces;
using InventoryAccounting.Infrastructure.Database;
using InventoryAccounting.Infrastructure.Repositories;
using InventoryAccounting.Infrastructure.UnitOfWork;
using InventoryAccounting.Service.Services;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DbConnectionFactory>();

//builder.Services.AddScoped<IDbConnection>(sp =>
//{
//    var factory = sp.GetRequiredService<DbConnectionFactory>();
//    return factory.CreateConnection();
//});


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<Func<IUnitOfWork>>(sp => () => sp.GetRequiredService<IUnitOfWork>());

//builder.Services.AddScoped<IItemMasterRepository, ItemMasterRepository>();
//builder.Services.AddScoped<IAccountRepository, AccountMasterRepository>();
//builder.Services.AddScoped<ISupplierRepository, SupplierMasterRepository>();
//builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
//builder.Services.AddScoped<ISaleRepository, SaleRepository>();

builder.Services.AddScoped<PurchaseService>();
builder.Services.AddScoped<SaleService>();
builder.Services.AddScoped<IReceiptService, ReceiptService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IItemMasterService, ItemMasterService>();
builder.Services.AddScoped<IAccountMasterService, AccountMasterService>();
builder.Services.AddScoped<ISupplierMasterServices, SupplierMasterService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
