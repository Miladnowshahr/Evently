﻿namespace Evently.Modules.Event.Application.TicketTypes.GetTicketType;

public sealed record TicketTypeResponse(
    Guid Id,
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    decimal Quantity);
