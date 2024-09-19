using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Modules.Event.Application.Abstractions.Messaging;
using Evently.Modules.Event.Application.Categories.GetCategory;

namespace Evently.Modules.Event.Application.Categories.GetCategories;
public sealed record GetCategoriesQuery : IQuery<IReadOnlyCollection<CategoryResponse>>;
