using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Modules.Events.Api.Events;
using Microsoft.AspNetCore.Routing;

namespace Evently.Module.Events.Presentation.Events;
public static class EventEndpoint
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CancelEvent.MapEndpoint(app);
        CreateEvent.MapEndpoint(app);
        GetEvent.MapEndpoint(app);
        GetEvents.MapEndpoint(app);
        PublishEvent.MapEndpoint(app);
        RescheduleEvent.MapEndpoint(app);
        SearchEvents.MapEndpoint(app);
    }
}
