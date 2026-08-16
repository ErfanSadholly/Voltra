using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Product : BaseEntity<int>
{
    [MaxLength(512)]
    public required string Name { get; set; }
    [MaxLength(3000)]
    public string? Description { get; set; }
    public int? BrandId { get; set; }
    public bool IsActive { get; set; }
    public Brand? Brand { get; set; }
}
