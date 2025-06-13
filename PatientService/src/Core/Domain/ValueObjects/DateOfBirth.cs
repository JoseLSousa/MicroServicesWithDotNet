namespace Domain.ValueObjects
{
    public sealed record DateOfBirth
    {
        public DateOnly Value { get; init; }

        public DateOfBirth(DateOnly value)
        {
            if(!Validate(value)) throw new ArgumentException("Invalid date of birth value.");
            Value = value;
        }
        private static bool Validate(DateOnly value)
        {
            return value <= DateOnly.FromDateTime(DateTime.UtcNow) && value >= DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-200));
        }
    }
}