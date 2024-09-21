using Evently.API.Extension;
using Evently.Modules.Events.Api;
using Evently.Common.Application;
using Evently.Common.Infrastructure;
using Serilog;
using Evently.API.Middleware;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context,loggerConfig) => { loggerConfig.ReadFrom.Configuration(context.Configuration); });

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddModuleConfiguration(["events","..."]);

builder.Services.AddApplication([Evently.Modules.Events.Application.AssemblyReference.Assembly]);
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Database")!,builder.Configuration.GetConnectionString("Cache")!);
builder.Services.AddEventsModule(builder.Configuration);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
}

app.UseHttpsRedirection();

EventsModule.MapEndpoints(app);

app.UseSerilogRequestLogging();
app.UseExceptionHandler();
app.Run();
