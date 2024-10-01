using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Common.Domain;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Event.Application.Events.GetEvent;
using Evently.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Api.Events;

internal  class CreateEvent : IEndpoint
{
    public  void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("events", async (Request request, ISender sender) =>
        {
            Result<Guid> eventId =  await sender.Send(new CreateEventCommand(request.CategoryId, request.Title, request.Description, request.Location, request.StartsAtUtc, request.EndsAtUtc));
            return Results.Ok(@eventId);

        }).WithTags(Tags.Events); 
    }
}
internal sealed class Request
{
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime StartsAtUtc { get; set; }
    public DateTime EndsAtUtc { get; set; }
}
