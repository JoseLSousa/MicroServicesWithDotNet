using Domain.ValueObjects;

namespace Test.Domain.ValueObjects
{

    public class CPFTests
    {
        [Fact]
        public void CPF_WithValidValue_ShouldAccept()
        {
            var validCpf = new CPF("123.456.789-09");

            Assert.Equal("12345678909", validCpf.Value);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void CPF_WithInvalidValue_ShouldThrowException(string value)
        {
            Assert.Throws<ArgumentException>(() => new CPF(value));
        }


        [Fact]
        public void CPFs_WithSameValue_ShouldBeEqual()
        {
            var cpf1 = new CPF("123.456.789-09");
            var cpf2 = new CPF("123.456.789-09");

            Assert.Equal(cpf1, cpf2);
            Assert.True(cpf1 == cpf2);
        }

        [Fact]
        public void CPFs_WithDifferentValues_ShouldBeDifferent()
        {
            var cpf1 = new CPF("123.456.789-09");
            var cpf2 = new CPF("987.654.321-00");

            Assert.NotEqual(cpf1, cpf2);
            Assert.False(cpf1 == cpf2);
        }
    }
}