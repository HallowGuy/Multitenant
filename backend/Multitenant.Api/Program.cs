using Microsoft.EntityFrameworkCore;
using Multitenant.Api.Data;
using Serilog;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console();

    var elasticUri = context.Configuration["Serilog:ElasticUrl"];
    if (!string.IsNullOrEmpty(elasticUri))
    {
        configuration.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
        {
            AutoRegisterTemplate = true,
            IndexFormat = "multitenant-api-{0:yyyy.MM.dd}"
        });
    }
});

// Ajouter la configuration de PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Autres services
builder.Services.AddControllers();

var app = builder.Build();

// Configuration du pipeline HTTP
app.UseSerilogRequestLogging();
app.MapControllers();

app.Run();
