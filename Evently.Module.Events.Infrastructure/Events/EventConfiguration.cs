using Evently.Modules.Events.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evently.Modules.Events.Infrastructure.Events;

internal sealed class EventConfiguration : IEntityTypeConfiguration<Domain.Events.Event>
{
    public void Configure(EntityTypeBuilder<Domain.Events.Event> builder)
    {
        builder.HasOne<Category>().WithMany();
    }
}
