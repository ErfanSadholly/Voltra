using Microsoft.AspNetCore.Identity;

namespace Domain;

public class User : IdentityUser<int> , IBaseId<int>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => this.FirstName + " " + this.LastName;
    public bool IsDeleted { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
}