﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Modules.Events.Api.Database;
using Evently.Modules.Events.Api.Events;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Modules.Events.Api;
public static class EventsModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateEvent.MapEndpoint(app);
        GetEvent.MapEndpoint(app);
    }

    public static IServiceCollection AddEventsModule(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConfigurationString = configuration.GetConnectionString("Database");

        services.AddDbContext<EventsDbContext>(options =>
        options.UseNpgsql(databaseConfigurationString,
            npgsqlOption => npgsqlOption.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemes.Events)).UseCamelCaseNamingConvention());

        return services;
    }
}
