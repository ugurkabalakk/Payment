using Application.Payment.Commands;
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
    public class CreatePaymentCommandValidatorTests
    {
        public CreatePaymentCommandValidator _validator { get; set; }
        public CreatePaymentCommandValidatorTests()
        {
            _validator = new CreatePaymentCommandValidator();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void CreatePayment_InvalidAmount_ShouldHaveValidationError(double amount)
        {
            var command = CreatePaymentCommandMother.Default();
            command.Amount = amount;
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(payment => payment.Amount);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CreatePayment_NullCurrencyCode_ShouldHaveValidationError(string currencyCode)
        {
            var command = CreatePaymentCommandMother.Default();
            command.CurrencyCode = currencyCode;

            var result= _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(payment => payment.CurrencyCode);
        }
    }
}
