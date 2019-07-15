using Kingpin.Tier.Entities.Classes;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Kingpin.Tier.Services.Interfaces
{
    public interface ITokenService : IBaseService
    {
        JwtSecurityToken GenerateJwtToken(string email, ApplicationUser identityUser);

        string WriteJwtToken(JwtSecurityToken jwtSecurityToken);

        SymmetricSecurityKey GenerateSymmetricSecurityKey();

        SigningCredentials GenerateSigningCredentials(SymmetricSecurityKey symmetricSecurityKey);

        List<Claim> GenerateJwtClaims(string email, ApplicationUser identityUser);
    }
}
