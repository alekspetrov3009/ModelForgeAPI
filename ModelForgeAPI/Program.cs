using FluentValidation;
using FluentValidation.AspNetCore;
using GenerationApi.Application.Models.Queries;
using MediatR;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Логирование
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Host.UseSerilog();

// Сервисы
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger с правильным пространством имен
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Generation API",
        Version = "v1",
        Description = "API для работы с параметрическими моделями и генерацией изделий"
    });

    // Дополнительные настройки OpenAPI
    c.UseAllOfToExtendReferenceSchemas();

    // XML-комментарии
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetModelsListQuery).Assembly));

// FluentValidation
builder.Services.AddValidatorsFromAssembly(typeof(GetModelsListQuery).Assembly);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Health Checks
builder.Services.AddHealthChecks();

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Generation API V1");
    c.RoutePrefix = "swagger";
    c.DocumentTitle = "Generation API";
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();