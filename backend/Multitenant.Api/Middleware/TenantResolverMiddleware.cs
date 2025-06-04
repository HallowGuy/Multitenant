using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Multitenant.Api.Middleware
{
    /// <summary>
    /// Middleware used to resolve the tenant identifier from the incoming request.
    /// It looks for the tenant in the following order:
    /// 1. The "X-Tenant-Id" header
    /// 2. The subdomain of the host (e.g. {tenant}.example.com)
    /// 3. The authenticated user's JWT claims ("tenant_id")
    /// </summary>
    public class TenantResolverMiddleware
    {
        public const string TenantIdItemKey = "TenantId";
        private const string TenantHeader = "X-Tenant-Id";
        private readonly RequestDelegate _next;

        public TenantResolverMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? tenantId = null;

            // 1. Header
            if (context.Request.Headers.TryGetValue(TenantHeader, out var headerValues))
            {
                tenantId = headerValues.FirstOrDefault();
            }

            // 2. Subdomain
            if (string.IsNullOrEmpty(tenantId))
            {
                var host = context.Request.Host.Host; // without port
                var parts = host.Split('.');
                if (parts.Length > 2)
                {
                    tenantId = parts[0];
                }
            }

            // 3. JWT claim
            if (string.IsNullOrEmpty(tenantId) && context.User?.Identity?.IsAuthenticated == true)
            {
                tenantId = context.User.Claims.FirstOrDefault(c => c.Type == "tenant_id")?.Value;
            }

            if (!string.IsNullOrWhiteSpace(tenantId))
            {
                context.Items[TenantIdItemKey] = tenantId;
            }

            await _next(context);
        }
    }
}
