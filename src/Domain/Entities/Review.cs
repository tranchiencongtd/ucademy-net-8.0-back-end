using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Review : BaseEntity<Guid>
{
    [Range(1, 5)]
    public int Rating { get; set; } // Rating out of 5

    [Required]
    [MaxLength(1000)]
    public required string Comment { get; set; }

    public DateTime ReviewDate { get; set; }

    [Required]
    public required User User { get; set; }

    [Required]
    public required Course Course { get; set; }
}
