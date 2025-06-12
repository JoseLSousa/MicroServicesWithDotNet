

using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public sealed partial record CPF
    {
        public string Value { get; }

        public CPF(string value)
        {

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("CPF cannot be null or empty.");

            string digitsOnly = MyRegex().Replace(value, "");
            if (digitsOnly.Distinct().Count() == 1)
                throw new ArgumentException("CPF cannot have all digits the same.");

            value = Regex.Replace(value, @"[^\d]", ""); // Remove non-numeric characters

            if (!Validate(value)) throw new ArgumentException("Invalid CPF value.");

            Value = value;
        }

        private static bool Validate(string value)
        {
            if (value.All(c => c == value[0]))
                return false;

            int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = value.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * mult1[i];

            int remainder = sum % 11;
            int firstDigit = remainder < 2 ? 0 : 11 - remainder;

            tempCpf += firstDigit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * mult2[i];

            remainder = sum % 11;
            int secondDigit = remainder < 2 ? 0 : 11 - remainder;

            return value.EndsWith($"{firstDigit}{secondDigit}");
        }

        [GeneratedRegex(@"[^\d]")]
        private static partial Regex MyRegex();
    }
}