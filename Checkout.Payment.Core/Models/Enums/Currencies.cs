using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Checkout.Payment.Core.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Currencies
    {
        USD,
        GBP,
        EUR,
        PLN,
        TRY
    }
}
