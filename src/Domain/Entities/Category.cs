using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category : BaseEntity<Guid>
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
