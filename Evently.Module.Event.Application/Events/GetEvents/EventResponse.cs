using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evently.Modules.Event.Application.Events.GetEvents;

public sealed record EventResponse(
Guid Id,
Guid CategoryId,
string Title,
string Description,
string Location,
DateTime StartsAtUtc,
DateTime? EndsAtUtc);
