using Evently.Common.Domain;

namespace Evently.Modules.Events.Domain.TicketType;

public sealed class TicketTypeCreatedDomainEvent(Guid ticketTypeId) : DomainEvent
{
    public Guid TicketTypeId { get; init; } = ticketTypeId;
}
