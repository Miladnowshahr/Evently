﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Modules.Event.Application.Abstractions.Messaging;
using Evently.Modules.Events.Application.Abstractions.Data;

namespace Evently.Modules.Event.Application.Events.PublishEvent;
public sealed record PublishEventCommand(Guid EventId) : ICommand;
