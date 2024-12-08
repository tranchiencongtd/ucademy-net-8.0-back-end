using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Course : BaseAuditableEntity<Guid>
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string Description { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [MaxLength(50)]
    public string Language { get; set; }

    public int Duration { get; set; } // Duration in minutes

    public ICollection<BitVector32.Section> Sections { get; set; } = new List<BitVector32.Section>();

    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<Category> Categories { get; set; } = new List<Category>();

    [Required] public Instructor Instructor { get; set; }
}
