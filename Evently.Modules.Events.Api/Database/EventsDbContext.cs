using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Api.Database;
public sealed class EventsDbContext(DbContextOptions<EventsDbContext> options):DbContext(options)
{
    //internal DbSet<Evently.Modules.Events> Events { get; set; }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.HasDefaultSchema(Schemes.Events);
    //}
}
