﻿using System.Net.Http;
using System.Net.Http.Json;
using Checkout.Payment.Core.Interfaces;
using Checkout.Payment.Core.Models;
using Checkout.Payment.Core.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Checkout.Payment.Infrastructure.Services
{
    public class AcquiringBankIntegrationService : IAcquiringBankIntegrationService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<BankSettings> _settings;
        public AcquiringBankIntegrationService(IHttpClientFactory httpClientFactory, IOptions<BankSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient();
            _settings = settings;
        }
        public async Task<BankResponse> SendAcquirer(BankRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync(_settings.Value.PaymentEndpoint, request);
            var response = JsonConvert.DeserializeObject<BankResponse>(await result.Content.ReadAsStringAsync());
            //we simply assume that a unique payment guid is generated by bank.
            response.PaymentTransactionId = Guid.NewGuid().ToString();
            response.ConfirmationTime = DateTime.Now;
            return response;
        }
    }
}
