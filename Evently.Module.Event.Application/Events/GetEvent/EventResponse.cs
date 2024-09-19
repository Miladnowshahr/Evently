﻿namespace Evently.Modules.Event.Application.Events.GetEvent;

public sealed record EventResponse(
    Guid Id,
    Guid CategoryId,
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc)
{
    public List<TicketTypeResponse> TicketTypes { get; } = [];
}
