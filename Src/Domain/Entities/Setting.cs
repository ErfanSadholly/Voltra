using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Setting : BaseEntity<int>
{
    [MaxLength(150)]
    public required string Key { get; set; }
    [MaxLength(512)]
    public required string Value { get; set; }
    [MaxLength(1024)]
    public string? Description { get; set; }
    public bool IsEncrypted { get; set; }       
}
