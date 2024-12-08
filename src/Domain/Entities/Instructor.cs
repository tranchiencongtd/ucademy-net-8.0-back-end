using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Instructor : BaseEntity<Guid>
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Column(TypeName = "text")]
    public string Bio { get; set; }
    
    public string ProfilePictureUrl { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
