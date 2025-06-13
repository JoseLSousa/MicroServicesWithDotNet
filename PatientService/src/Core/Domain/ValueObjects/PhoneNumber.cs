using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public sealed record PhoneNumber
    {
        public string? Value { get; private set; }

        public PhoneNumber(string value)
        {
            const string pattern = @"\D";

            value = Regex.Replace(value, pattern, "");

            if (value.Length != 11 || value.Length == 0)
                throw new ArgumentException("Phone number must be exactly 11 digits long.", nameof(value));

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone number cannot be null or empty.", nameof(value));

            Value = value;
        }
        public override string ToString() => Value!;
    }
}