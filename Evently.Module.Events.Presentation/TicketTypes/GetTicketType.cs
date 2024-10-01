using Evently.Common.Domain;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Event.Application.TicketTypes.GetTicketType;
using Evently.Modules.Events.Api;
using Evently.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.TicketTypes;

internal  class GetTicketType : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("ticket-types/{id}", async (Guid id, ISender sender) =>
        {
            Result<TicketTypeResponse> result = await sender.Send(new GetTicketTypeQuery(id));

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.TicketTypes);
    }
}
