using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class RefreshToken
{
    public int Id { get; set; } 
    public int UserId { get; set; }
    [MaxLength(520)]
    public required string Token { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime RevokedAt { get; set; } 
    public User User { get; set; }
}
