using Checkout.Payment.Core.Interfaces;
using Checkout.Payment.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTransactionController : ControllerBase
    {
        private readonly ILogger<PaymentTransactionController> _logger;
        private readonly IPaymentTransactionService _paymentTransactionService;
        public PaymentTransactionController(ILogger<PaymentTransactionController> logger, IPaymentTransactionService paymentService)
        {
            _logger = logger;
            _paymentTransactionService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult> GetTransaction(Guid id)
        {
            try
            {
                var result = await _paymentTransactionService.GetPayment(id.ToString());
                return new OkObjectResult(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult> SendTransaction([FromBody]PaymentTransactionRequest payment)
        {
            try
            {
                var result = await _paymentTransactionService.SendPayment(payment);
                return new OkObjectResult(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}
