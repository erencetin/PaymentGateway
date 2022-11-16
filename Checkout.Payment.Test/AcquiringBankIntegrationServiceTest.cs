using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Checkout.Payment.Core.Interfaces;
using Checkout.Payment.Core.Models;
using Checkout.Payment.Core.Models.Enums;
using Checkout.Payment.Core.Settings;
using Checkout.Payment.Infrastructure.Services;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace Checkout.Payment.Test
{
    [TestFixture]
    public class AcquiringBankIntegrationServiceTest
    {
        
        private Mock<IHttpClientFactory> _clientFactoryMock;
        private Mock<IOptions<BankSettings>> _bankSettingsMock;

        [SetUp]
        public void SetUp()
        {
            _clientFactoryMock = new Mock<IHttpClientFactory>();
            _bankSettingsMock = new Mock<IOptions<BankSettings>>();
            _bankSettingsMock.Setup(o => o.Value).Returns(new BankSettings()
            {
                PaymentEndpoint = "https://test.com/"
            });
        }

        [Test]
        public async Task SendAcquirerShouldAcceptPayments()
        {
            var bankRequest = new BankRequest()
            {
                Amount = 10,
                CardName = "Test Test",
                CardNumber = "3443233290098776",
                Currency = Currencies.GBP,
                Cvv = 254,
                ExpireDate = new DateTime(2026, 12, 15)
            };

            var httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            HttpClient httpClient = new HttpClient(httpMessageHandlerMock.Object);
            //employeeApiClientService = new EmployeeApiClientService(httpClient);
            httpMessageHandlerMock.Protected().Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            ).ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(new BankResponse()), Encoding.UTF8, "application/json")
            }).Verifiable();

            _clientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);
            var service = new AcquiringBankIntegrationService(_clientFactoryMock.Object, _bankSettingsMock.Object);
            var result = await service.SendAcquirer(bankRequest);
            Assert.NotNull(result);
            Assert.AreEqual(PaymentStatus.Successful, result.Status);
            Assert.AreEqual(36, result.PaymentTransactionId.Length);
        }
    }
}
