using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Lecture : BaseEntity<Guid>
{
    [Required]
    [MaxLength(150)]
    public required string Title { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(250)")]
    public required string Slug { get; set; }
    
    public int Order { get; set; } // Order of the lecture in the section

    [Required]
    public required string VideoUrl { get; set; }

    [Required]
    public required Section Section { get; set; }
}
