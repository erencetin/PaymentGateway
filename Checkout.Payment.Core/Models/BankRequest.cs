using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.Payment.Core.Models.Enums;

namespace Checkout.Payment.Core.Models
{
    public class BankRequest
    {
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Cvv { get; set; }
        public decimal Amount { get; set; }
        public Currencies Currency { get; set; }
    }
}
