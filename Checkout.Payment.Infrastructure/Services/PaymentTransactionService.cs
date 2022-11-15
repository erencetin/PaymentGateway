using Checkout.Payment.Core.Interfaces;
using Checkout.Payment.Core.Models;
using Microsoft.Extensions.Logging;

namespace Checkout.Payment.Infrastructure.Services
{
    public class PaymentTransactionService : IPaymentTransactionService
    {
        private readonly ILogger<PaymentTransactionService> _logger;
        private readonly IAcquiringBankIntegrationService _bankIntegration;
        private readonly IPaymentRepository _repository;
        private readonly ICreditCardService _cardService;
        public PaymentTransactionService(ILogger<PaymentTransactionService> logger, 
            IAcquiringBankIntegrationService bankIntegration, 
            IPaymentRepository repository,
            ICreditCardService cardService)
        {
            _logger = logger;
            _bankIntegration = bankIntegration;
            _repository = repository;
            _cardService = cardService;
        }
        
        public async Task<PaymentTransactionResponse> GetPayment(string paymentId)
        {
            var payment = await _repository.GetPaymentDetailsByPaymentId(paymentId);
            return new PaymentTransactionResponse()
            {
                Amount = payment.Amount,
                CardName = payment.CardName,
                Currency = payment.Currency,
                CustomerName = payment.CustomerName,
                MerchantId = payment.MerchantId,
                PaymentId = payment.PaymentId,
                Status = payment.PaymentStatus,
                TransactionTime = payment.TransactionTime

            };
        }
        
        public async Task<PaymentTransactionResponse> SendPayment(PaymentTransactionRequest payment)
        {
            var bankRequest = new BankRequest()
            {
                Amount = payment.Amount,
                CardName = payment.CardName,
                CardNumber = payment.CardNumber,
                Currency = payment.Currency,
                Cvv = payment.Cvv,
                ExpireDate = payment.ExpireDate
            };

            var response = await _bankIntegration.SendAcquirer(bankRequest);
            var paymentDbEntity = new PaymentTransaction()
            {
                PaymentId = response.PaymentTransactionId,
                Amount = payment.Amount,
                CardName = payment.CardName,
                CustomerName = payment.CustomerName,
                CardNumer = _cardService.MaskCardNumber(payment.CardNumber),
                Currency = payment.Currency,
                MerchantId = payment.MerchantId,
                PaymentStatus = response.Status,
                TransactionTime = payment.TransactionTime,
                BankConfirmationTime = response.ConfirmationTime
            };

            var dbResult = await _repository.AddPaymentTransaction(paymentDbEntity);

            return new PaymentTransactionResponse()
            {
                Status = response.Status,
                PaymentId = response.PaymentTransactionId,
                Amount = payment.Amount,
                CardName = payment.CardName, CustomerName = payment.CustomerName,
                Currency = payment.Currency,
                MerchantId = payment.MerchantId,
                TransactionTime = payment.TransactionTime
            };
        }
    }
}
