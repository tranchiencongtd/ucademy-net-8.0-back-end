using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User : BaseEntity<Guid>
{
    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MaxLength(200)]
    public string PasswordHash { get; set; }  // Assumed hash is stored

    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<Course> EnrolledCourses { get; set; } = new List<Course>();
}
