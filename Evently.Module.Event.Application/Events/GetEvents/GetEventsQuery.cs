using Evently.Modules.Event.Application.Abstractions.Messaging;

namespace Evently.Modules.Event.Application.Events.GetEvents;

public sealed record GetEventsQuery : IQuery<IReadOnlyCollection<EventResponse>>;

