using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Course : BaseAuditableEntity<Guid>
{
    [Required]
    [MaxLength(200)]
    public required string Title { get; set; }

    [Required]
    [Column(TypeName = "varchar(250)")]
    public required string Slug { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(18,0)")]
    public decimal Price { get; set; }

    [MaxLength(50)]
    public string? Language { get; set; }

    public int Duration { get; set; } // Duration in minutes

    public ICollection<Section> Sections { get; set; } = new List<Section>();

    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<Category> Categories { get; set; } = new List<Category>();

    [Required]
    public required User User { get; set; }
}
