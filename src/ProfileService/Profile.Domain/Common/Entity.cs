using System.ComponentModel.DataAnnotations.Schema;

namespace Profile.Domain.Common;

// TODO: Refactor to hide domain event interation
public abstract class Entity
{
    private readonly List<Event> _domainEvents = new();

    public Guid Id { get; protected set; }

    [NotMapped]
    public IReadOnlyCollection<Event> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(Event domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(Event domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
