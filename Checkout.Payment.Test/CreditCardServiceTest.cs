using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.Payment.Core.Interfaces;
using Checkout.Payment.Infrastructure.Services;

namespace Checkout.Payment.Test
{
    [TestFixture]
    public class CreditCardServiceTest
    {
        private ICreditCardService _creditCardService;
        [SetUp]
        public void SetUp()
        {
            _creditCardService = new CreditCardService();
        }

        [Test]
        public void MaskCardNumberShouldMaskCorrectly()
        {
            var cardNo = "5623434851000498";
            var expectedMaskedNo = "************0498";
            var result = _creditCardService.MaskCardNumber(cardNo);
            Assert.AreEqual(expectedMaskedNo, result);
        }
    }
}
