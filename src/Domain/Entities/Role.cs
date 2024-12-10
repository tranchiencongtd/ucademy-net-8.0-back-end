using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Role : BaseEntity<Guid>
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
