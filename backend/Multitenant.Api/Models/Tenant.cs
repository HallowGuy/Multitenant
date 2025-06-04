using System.ComponentModel.DataAnnotations;

namespace Multitenant.Api.Models
{
    public class Tenant
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
