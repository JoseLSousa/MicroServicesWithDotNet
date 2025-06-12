
using Application.Shared.Behaviors;
using Domain.ValueObjects;
using FluentValidation.TestHelper;

namespace Test.Application.Shared.Behaviors
{
    public class EmailValidatorTests
    {
        private readonly EmailValidator _validator = new();


        [Fact]
        public void Email_WithEmptyValue_ShouldReturnError()
        {
            var email = new Email(string.Empty);

            var result = _validator.TestValidate(email);

            result.ShouldHaveValidationErrorFor(e => e.Value)
                .WithErrorMessage("Email cannot be empty.");
        }

        [Fact]
        public void Email_WithInvalidValue_ShouldReturnError()
        {
            var email = new Email("invalid-email");

            var result = _validator.TestValidate(email);

            result.ShouldHaveValidationErrorFor(e => e.Value)
                .WithErrorMessage("Invalid email format.");
        }

        [Fact]
        public void Email_WithValidValue_ShouldAccept()
        {
            var email = new Email("contoso@email.com");

            var result = _validator.TestValidate(email);

            result.ShouldNotHaveValidationErrorFor(e => e.Value);
        }
    }
}