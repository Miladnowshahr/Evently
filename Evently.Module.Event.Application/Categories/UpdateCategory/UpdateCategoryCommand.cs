using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Evently.Modules.Event.Application.Abstractions.Messaging;
using Evently.Modules.Events.Application.Abstractions.Data;

namespace Evently.Modules.Event.Application.Categories.UpdateCategory;
public sealed record UpdateCategoryCommand(Guid CategoryId, string Name) : Abstractions.Messaging.ICommand;
