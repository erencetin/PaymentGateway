using Checkout.Payment.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.Payment.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastractureServices(this IServiceCollection services)
        {
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ITestService, TestService>();
        }
    }
}