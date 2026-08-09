using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class User : IdentityUser<int>, IBaseId<int>
{
    [MaxLength(50)]
    public required string FirstName { get; set; }
    [MaxLength(50)]
    public required string LastName { get; set; }
    public string FullName => this.FirstName + " " + this.LastName;
    public bool IsDeleted { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
}