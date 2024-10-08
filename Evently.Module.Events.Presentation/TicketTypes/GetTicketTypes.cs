﻿using Evently.Common.Domain;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Event.Application.TicketTypes.GetTicketType;
using Evently.Modules.Event.Application.TicketTypes.GetTicketTypes;
using Evently.Modules.Events.Api;
using Evently.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.TicketTypes;

internal  class GetTicketTypes : IEndpoint
{
    public  void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("ticket-types", async (Guid eventId, ISender sender) =>
        {
            Result<IReadOnlyCollection<TicketTypeResponse>> result = await sender.Send(
                new GetTicketTypesQuery(eventId));

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.TicketTypes);
    }
}
