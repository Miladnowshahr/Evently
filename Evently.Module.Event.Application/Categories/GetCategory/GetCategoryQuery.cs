using Evently.Common.Application.Messaging;

namespace Evently.Modules.Event.Application.Categories.GetCategory;

public sealed record GetCategoryQuery(Guid CategoryId) : IQuery<CategoryResponse>;
