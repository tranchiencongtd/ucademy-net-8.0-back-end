using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class User : BaseEntity<Guid>
{
    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public required string Username { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [MaxLength(200)]
    public required string PasswordHash { get; set; }  // Assumed hash is stored

    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<Course> EnrolledCourses { get; set; } = new List<Course>();
    
    // Instructor-related fields
    [MaxLength(100)]
    public string? Name { get; set; }  // Optional field when the user is an instructor

    [Column(TypeName = "text")]
    public string? Bio { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();

    // Roles
    public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
}
