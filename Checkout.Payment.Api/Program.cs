using System.Net;
using Checkout.Payment.Core.Interfaces;
using Checkout.Payment.Core.Settings;
using Checkout.Payment.Infrastructure.Data;
using Checkout.Payment.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.ExampleFilters();
});
builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();
builder.Services.AddLogging();
builder.Services.AddDbContext<PaymentContext>
    (o => o.UseInMemoryDatabase("PaymentDb"));
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentTransactionService, PaymentTransactionService>();
builder.Services.AddScoped<IAcquiringBankIntegrationService, AcquiringBankIntegrationService>();
builder.Services.AddScoped<ICreditCardService, CreditCardService>();
var bankSettingsSection = builder.Configuration.GetSection("BankSettings");
builder.Services.Configure<BankSettings>(bankSettingsSection);

builder.Services.AddHttpClient(Options.DefaultName)
    .ConfigurePrimaryHttpMessageHandler(h =>
    {
        var handler = new HttpClientHandler();
        handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.Brotli;
        return handler;
    });
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