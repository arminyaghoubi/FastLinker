using FastLinker.Infrastructure;
using FastLinker.Persistence;
using FastLinker.Application;
using Serilog;
using FastLinker.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((context, configure) =>
    configure.WriteTo.Console()
    .ReadFrom.Configuration(context.Configuration));

builder.Services.AddPersistenceServices(builder.Configuration)
    .AddInfrastructureServices()
    .AddApplicationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
