
using Domain.ValueObjects;

namespace Test.Domain.ValueObjects
{
    public class PhoneNumberTests
    {
        [Fact]
        public void PhoneNumber_WithEmptyValue_ShouldThrowException()
        {
            var invalidPhoneNumber = string.Empty;

            Assert.Throws<ArgumentException>(() => new PhoneNumber(invalidPhoneNumber));
        }

        [Fact]
        public void PhoneNumber_WithValidValue_ShouldSetValue()
        {
            var validPhoneNumber = "(99) 9 9999-9999";
            var phoneNumber = new PhoneNumber(validPhoneNumber);
            Assert.Equal("99999999999", phoneNumber.Value);
        }

        [Fact]
        public void PhoneNumber_WithInvalidLength_ShouldThrowException()
        {
            var invalidPhoneNumber = "12345";
            Assert.Throws<ArgumentException>(() => new PhoneNumber(invalidPhoneNumber));
        }

        [Fact]
        public void PhoneNumber_ToString()
        {
            var validPhoneNumber = "(99) 9 9999-9999";
            var phoneNumber = new PhoneNumber(validPhoneNumber);
            Assert.Equal("99999999999", phoneNumber.ToString());
        }

    }
}