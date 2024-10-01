using Evently.Common.Domain;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Event.Application.Events.GetEvents;
using Evently.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using EventResponse = Evently.Modules.Event.Application.Events.GetEvents.EventResponse;

namespace Evently.Modules.Events.Api.Events;

internal  class GetEvents : IEndpoint
{
    public  void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events", async (ISender sender) =>
        {
            Result<IReadOnlyCollection<EventResponse>> result = await sender.Send(new GetEventsQuery());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Events);
    }
}
