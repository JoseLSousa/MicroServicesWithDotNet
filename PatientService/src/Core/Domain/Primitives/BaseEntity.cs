namespace Domain.Primitives
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }
        public bool Active { get; private set; } = true;

        public void Deactivate()
        {
            Active = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdatedDate() => UpdatedAt = DateTime.UtcNow;
    }
}