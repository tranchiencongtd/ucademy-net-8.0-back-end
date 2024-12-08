using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Review : BaseEntity<Guid>
{
    [Range(1, 5)]
    public int Rating { get; set; } // Rating out of 5

    [MaxLength(1000)]
    public string Comment { get; set; }

    public DateTime ReviewDate { get; set; }

    [Required]
    public User User { get; set; }

    [Required]
    public Course Course { get; set; }
}
