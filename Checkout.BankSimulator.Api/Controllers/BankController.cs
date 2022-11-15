using Checkout.Payment.Core.Models;
using Checkout.Payment.Core.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.BankSimulator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly ILogger<BankController> _logger;

        public BankController(ILogger<BankController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult SendPayment(PaymentTransaction payment)
        {
            //Process the incoming payment.
            //Send fake response.
            var bankResponse = new BankResponse
            {
                PaymentTransactionId = Guid.NewGuid(),
                Status = PaymentStatus.Successful
            };
            _logger.LogInformation("Received payment successfully");
            return new OkObjectResult(bankResponse);
        }
    }
}
