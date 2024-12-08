using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Lecture : BaseEntity<Guid>
{
    [Required]
    [MaxLength(150)]
    public string Title { get; set; }

    public int Order { get; set; } // Order of the lecture in the section

    [Url]
    public string VideoUrl { get; set; }

    [Required]
    public Section Section { get; set; }
}
