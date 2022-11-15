using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Payment.Core.Interfaces
{
    public interface ICreditCardService
    {
        string MaskCardNumber(string cardNumber);
    }
}
