using Evently.Modules.Event.Application.Events.GetEvents;

namespace Evently.Modules.Event.Application.Events.SearchEvents;

public sealed record SearchEventsResponse(
    int Page,
    int PageSize,
    int TotalCount,
    IReadOnlyCollection<EventResponse> Events);
