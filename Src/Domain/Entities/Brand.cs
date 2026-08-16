using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Brand : BaseEntity<int>
{
    [MaxLength(128)]
    public required string Name { get; set; }
    [MaxLength(1024)]
    public string? LogoUrl { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>(); 
}
