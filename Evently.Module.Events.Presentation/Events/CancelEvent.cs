using Evently.Common.Domain;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Event.Application.Events.CancelEvent;
using Evently.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Api.Events;

internal  class CancelEvent : IEndpoint
{
    public  void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("events/{id}/cancel", async (Guid id, ISender sender) =>
        {
            Result result = await sender.Send(new CancelEventCommand(id));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
        .WithTags(Tags.Events);
    }
}

