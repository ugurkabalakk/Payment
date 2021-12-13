using Application.Payment.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mothers
{
    internal static class GetPaymentQueryMother
    {
        public static GetPaymentQuery Default()
        {
            return new GetPaymentQuery()
            {
                PaymentId = "61b50627806ed346ca40dda6"
            };
        }
    }
}
