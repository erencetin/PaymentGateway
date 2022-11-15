using Checkout.Payment.Core.Interfaces;

namespace Checkout.Payment.Infrastructure.Services
{
    public class CreditCardService : ICreditCardService
    {
        public string MaskCardNumber(string cardNumber)
        {
            var maskedCardNo = string.Empty;
            var cardIndexStart = cardNumber.Length - 4;

            for (int i = 0; i < cardIndexStart; i++)
            {
                maskedCardNo += "*";
            }

            return maskedCardNo += cardNumber.Substring(cardIndexStart);
        }
    }
}
