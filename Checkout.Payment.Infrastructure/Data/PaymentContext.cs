using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.Payment.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Payment.Infrastructure.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext>
            options) : base(options)
        {

        }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
    }
}
