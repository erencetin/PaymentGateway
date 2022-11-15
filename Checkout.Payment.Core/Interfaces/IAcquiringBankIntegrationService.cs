using Checkout.Payment.Core.Models;

namespace Checkout.Payment.Core.Interfaces
{
    public interface IAcquiringBankIntegrationService
    {
        Task<BankResponse> SendAcquirer(BankRequest request);
    }
}
