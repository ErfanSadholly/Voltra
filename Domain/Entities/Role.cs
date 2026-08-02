using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Role : IdentityRole<int> , IBaseId<int>
{
    [MaxLength(1024)]
    public string? Description { get; set; }    
}