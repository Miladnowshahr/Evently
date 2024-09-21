using Evently.Common.Application.Messaging;

namespace Evently.Modules.Event.Application.Events.GetEvents;

public sealed record GetEventsQuery : IQuery<IReadOnlyCollection<EventResponse>>;

