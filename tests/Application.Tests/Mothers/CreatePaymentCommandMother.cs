using Application.Payment.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mothers
{
    internal static class CreatePaymentCommandMother
    {
        public static CreatePaymentCommand Default()
        {
            return new CreatePaymentCommand()
            {
                Amount = 1,
                CurrencyCode = "TL",
                OrderInformation = new OrderInformation()
                {
                    ConsumerAddress = "ugur",
                    ConsumerFullName = "ugur address"
                }
            };
        }
    }
}
