using Microsoft.EntityFrameworkCore;
using Multitenant.Api.Data;
using Multitenant.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Ajouter la configuration de PostgreSQL depuis les variables d'environnement
var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
    ?? throw new InvalidOperationException("Connection string not configured");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Autres services
builder.Services.AddControllers();

var app = builder.Build();

// Configuration du pipeline HTTP
app.UseMiddleware<TenantResolverMiddleware>();
app.MapControllers();

app.Run();
