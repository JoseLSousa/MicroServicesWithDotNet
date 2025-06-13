
using Domain.ValueObjects;

namespace Test.Domain.ValueObjects
{
    public class DateOfBirthTests
    {
        [Fact]
        public void DateOfBirth_WithAFutureDate_ShouldThrowException()
        {
            var futureDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(1));

            Assert.Throws<ArgumentException>(() => new DateOfBirth(futureDate));
        }
        
        
    }
}