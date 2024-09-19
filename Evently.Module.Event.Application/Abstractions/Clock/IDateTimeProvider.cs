using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evently.Modules.Event.Application.Abstractions.Clock;
public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}
