using Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Features;

public partial class UserFeature
{
    public async Task<Result<string>> Jwt(User user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>
        {
             new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
             new Claim(ClaimTypes.Name , user.FullName),
             new Claim(ClaimTypes.MobilePhone , user.PhoneNumber),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        claims.AddRange(roles.Select(i => new Claim(ClaimTypes.Role, i)));

        var secretKey = _configuration["Jwt:SecretKey"];

        var token = new JwtSecurityToken
        (
             claims: claims, 
             expires: DateTime.Now.AddHours(2),
             signingCredentials: new SigningCredentials
             (new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(secretKey!)),            
            SecurityAlgorithms.HmacSha256Signature)
        );

        return Result<string>.SuccessRes(new JwtSecurityTokenHandler().WriteToken(token));
    }
}
