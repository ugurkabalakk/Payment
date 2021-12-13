using Application.Payment.Queries;
using Application.Tests.Mothers;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.Payment
{
    public class GetPaymentQueryTests
    {

        public GetPaymentQueryValidator _validator { get; set; }
        public GetPaymentQueryTests()
        {
            _validator = new GetPaymentQueryValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void GetPayment_NullPaymentId_ShouldHaveValidationError(string paymentId)
        {
            var query = GetPaymentQueryMother.Default();
            query.PaymentId = paymentId;

            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(payment => payment.PaymentId);
        }
    }
}
