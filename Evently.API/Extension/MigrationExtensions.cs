using System.Runtime.CompilerServices;
using Evently.Modules.Events.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace Evently.API.Extension;

public static class MigrationExtensions
{
    public static void ApplyMigration(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        ApplyMigration<EventsDbContext>(scope);

    }
    private static void ApplyMigration<TDbContext>(IServiceScope scope)where TDbContext:DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();  
        context.Database.Migrate();
    }
}
