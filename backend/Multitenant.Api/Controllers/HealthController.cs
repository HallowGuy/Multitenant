using Microsoft.AspNetCore.Mvc;
using Multitenant.Api.Middleware;

namespace Multitenant.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var tenantId = HttpContext.Items[TenantResolverMiddleware.TenantIdItemKey]?.ToString();
            if (tenantId is null)
                return BadRequest("Tenant not resolved");
            return Ok(new { status = "Healthy", timestamp = DateTime.UtcNow, tenant = tenantId });
        }
    }
}
