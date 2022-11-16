using Checkout.Payment.Core.Models;
using Checkout.Payment.Core.Models.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace Checkout.Payment.Api.SwaggerExamples
{
    public class PaymentTransactionResponseExample : IExamplesProvider<PaymentTransactionResponse>
    {
        public PaymentTransactionResponse GetExamples()
        {
            return new PaymentTransactionResponse
            {
                Amount = 16.7M,
                CardName = "James Dean",
                Currency = Currencies.GBP,
                CustomerName = "James Dean",
                MerchantId = "ed6ce9e9-a573-45af-963d-8bc724a09161",
                TransactionTime = DateTime.Now,
                PaymentId = Guid.NewGuid().ToString(),
                Status = PaymentStatus.Successful
            };
        }

    }
}
