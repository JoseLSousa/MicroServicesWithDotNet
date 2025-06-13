using Domain.Enums;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Patient : BaseEntity
    {
        public string? FullName { get; private set; }
        public Email? Email { get; private set; }
        public CPF? CPF { get; private set; }
        public Gender Gender { get; private set; }
        public DateOfBirth? DateOfBirth { get; private set; }
        public PhoneNumber? PhoneNumber { get; private set; }
        public string? Address { get; private set; }
    }
}