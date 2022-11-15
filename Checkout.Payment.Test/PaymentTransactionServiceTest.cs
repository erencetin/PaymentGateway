using Checkout.Payment.Core.Interfaces;
using Checkout.Payment.Core.Models;
using Checkout.Payment.Core.Models.Enums;
using Checkout.Payment.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace Checkout.Payment.Test
{
    public class PaymentTransactionServiceTest
    {
        private Mock<IAcquiringBankIntegrationService> _mockAcquireBankIntegration;
        private Mock<ILogger<PaymentTransactionService>> _mockLogger;
        private Mock<IPaymentRepository> _paymentRepository;
        private IPaymentTransactionService _paymentTransactionService;
        

        [SetUp]
        public void Setup()
        {
            _mockAcquireBankIntegration = new Mock<IAcquiringBankIntegrationService>();
            _mockLogger = new Mock<ILogger<PaymentTransactionService>>();
            _paymentRepository = new Mock<IPaymentRepository>();
            _paymentTransactionService = new PaymentTransactionService(_mockLogger.Object, _mockAcquireBankIntegration.Object, _paymentRepository.Object, new CreditCardService());
        }

        [Test]
        public async Task SendPaymentShouldSendTransactionToBank()
        {
            BankRequest bankRequest = new BankRequest();
            bankRequest.Amount = 1;
            bankRequest.CardName = "ABC DEF";
            bankRequest.CardNumber = "43462342234786";
            bankRequest.Currency = Currencies.GBP;
            bankRequest.Cvv = 116;
            bankRequest.ExpireDate = new DateTime(2026, 12, 1);
            PaymentTransactionRequest paymentreRequest = new PaymentTransactionRequest()
            {
                Amount = 1,
                CardName = bankRequest.CardName,
                CardNumber = bankRequest.CardNumber,
                Currency = bankRequest.Currency,
                ExpireDate = bankRequest.ExpireDate,
                CustomerName = "James Dean",
                Cvv = bankRequest.Cvv,
                MerchantId = "1123eerf33",
                TransactionTime = DateTime.Now
            };
            var expectedGuid = Guid.NewGuid().ToString();
            BankResponse expectedBankResponse = new BankResponse()
            {
                PaymentTransactionId = expectedGuid,
                Status = PaymentStatus.Successful
            };

            _mockAcquireBankIntegration.Setup(x => x.SendAcquirer(It.IsAny<BankRequest>())).ReturnsAsync(expectedBankResponse);
            var result = await _paymentTransactionService.SendPayment(paymentreRequest);

            Assert.AreEqual(expectedGuid, result.PaymentId);
            Assert.AreEqual(PaymentStatus.Successful, result.Status);
        }
    }
}