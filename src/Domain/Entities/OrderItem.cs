using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class OrderItem : BaseEntity<int>
{
    [Required]
    public required Course Course { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,0)")]
    public decimal Price { get; set; }

    [Required]
    public required Order Order { get; set; }
}
