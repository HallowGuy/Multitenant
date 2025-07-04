using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multitenant.Api.Data;
using Multitenant.Api.Models;
using Multitenant.Api.Middleware;

namespace Multitenant.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenantsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TenantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string? TenantId => HttpContext.Items[TenantResolverMiddleware.TenantIdItemKey]?.ToString();


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tenant>>> GetTenants()
        {
            if (TenantId is null) return BadRequest("Tenant not resolved");
            return await _context.Tenants.OrderBy(t => t.Name).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tenant>> GetTenant(Guid id)
        {
            if (TenantId is null) return BadRequest("Tenant not resolved");
            var tenant = await _context.Tenants.FindAsync(id);
            return tenant == null ? NotFound() : Ok(tenant);
        }

        [HttpPost]
        public async Task<ActionResult<Tenant>> CreateTenant([FromBody] Tenant tenant)
        {
            if (TenantId is null) return BadRequest("Tenant not resolved");
            tenant.Id = Guid.NewGuid();
            tenant.CreatedAt = DateTime.UtcNow;
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTenant), new { id = tenant.Id }, tenant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTenant(Guid id, [FromBody] Tenant tenant)
        {
            if (TenantId is null) return BadRequest("Tenant not resolved");
            if (id != tenant.Id)
                return BadRequest("L'ID ne correspond pas.");

            var existing = await _context.Tenants.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Name = tenant.Name;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenant(Guid id)
        {
            if (TenantId is null) return BadRequest("Tenant not resolved");
            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null) return NotFound();

            _context.Tenants.Remove(tenant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
