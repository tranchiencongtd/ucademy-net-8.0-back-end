using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Section : BaseEntity<Guid>
{
    [Required]
    [MaxLength(150)]
    public string Title { get; set; }

    public int Order { get; set; } // Order of the section in the course

    public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

    [Required]
    public Course Course { get; set; }
}
