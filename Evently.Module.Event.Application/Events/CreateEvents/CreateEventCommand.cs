﻿using Evently.Common.Application.Messaging;
using MediatR;

namespace Evently.Modules.Events.Api.Events;
public sealed record CreateEventCommand(
    Guid CategoryId,
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc) : ICommand<Guid>;
