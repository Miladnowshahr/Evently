using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Modules.Event.Application.Abstractions.Messaging;
using Evently.Modules.Event.Application.TicketTypes.GetTicketType;

namespace Evently.Modules.Event.Application.TicketTypes.GetTicketTypes;
public sealed record GetTicketTypesQuery(Guid EventId) : IQuery<IReadOnlyCollection<TicketTypeResponse>>;
