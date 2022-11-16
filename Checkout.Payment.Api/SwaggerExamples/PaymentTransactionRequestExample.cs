using Checkout.Payment.Core.Models;
using Checkout.Payment.Core.Models.Enums;
using Swashbuckle.AspNetCore.Filters;


namespace Checkout.Payment.Api.SwaggerExamples
{
    public class PaymentTransactionRequestExample : IExamplesProvider<PaymentTransactionRequest>
    {
        public PaymentTransactionRequest GetExamples()
        {
            return new PaymentTransactionRequest
            {
                Amount = 16.7M,
                CardName = "James Dean",
                CardNumber = "5674112123432345",
                Currency = Currencies.GBP,
                CustomerName = "James Dean",
                Cvv = 116,
                ExpireDate = new DateTime(2026, 12, 1),
                MerchantId = Guid.NewGuid().ToString(),
                TransactionTime = DateTime.Now
            };
        }
    }
}
