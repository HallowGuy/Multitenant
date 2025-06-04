using Microsoft.EntityFrameworkCore;
using Multitenant.Api.Data;
using Multitenant.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Ajouter la configuration de PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Autres services
builder.Services.AddControllers();

var app = builder.Build();

// Configuration du pipeline HTTP
app.UseMiddleware<TenantResolverMiddleware>();
app.MapControllers();

app.Run();
