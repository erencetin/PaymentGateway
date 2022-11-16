using Checkout.Payment.Api.SwaggerExamples;
using Checkout.Payment.Core.Interfaces;
using Checkout.Payment.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

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
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PaymentTransactionResponseExample))]
        public async Task<ActionResult<PaymentTransactionResponse>> GetTransaction(string id)
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
        [SwaggerRequestExample(typeof(PaymentTransactionRequest), typeof(PaymentTransactionRequestExample))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PaymentTransactionResponseExample))]
        [ProducesResponseType(typeof(PaymentTransactionResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaymentTransactionResponse>> SendTransaction([FromBody]PaymentTransactionRequest payment)
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
