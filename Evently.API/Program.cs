using Evently.API.Extension;
using Evently.Modules.Events.Api;
using Evently.Common.Application;
using Evently.Common.Infrastructure;
using Serilog;
using Evently.API.Middleware;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Evently.Common.Presentation.Endpoints;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => { loggerConfig.ReadFrom.Configuration(context.Configuration); });

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddModuleConfiguration(["events", "..."]);

string databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;
string redisConnectionString = builder.Configuration.GetConnectionString("Cache")!;

builder.Services.AddApplication([Evently.Modules.Events.Application.AssemblyReference.Assembly]);
builder.Services.AddInfrastructure(databaseConnectionString, builder.Configuration.GetConnectionString("Cache")!);
builder.Services.AddEventsModule(builder.Configuration);

builder.Services.AddHealthChecks().AddNpgSql(databaseConnectionString);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.MapHealthChecks("health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseSerilogRequestLogging();
app.UseExceptionHandler();
app.Run();
