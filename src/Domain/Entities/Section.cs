using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Section : BaseEntity<Guid>
{
    [Required]
    [MaxLength(150)]
    public required string Title { get; set; }

    [Required]
    [Column(TypeName = "varchar(250)")]
    public required string Slug { get; set; }
    
    public int Order { get; set; } // Order of the section in the course

    public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

    [Required]
    public required Course Course { get; set; }
}
