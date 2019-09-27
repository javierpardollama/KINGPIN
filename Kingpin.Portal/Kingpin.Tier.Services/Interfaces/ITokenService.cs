using System.Collections.Generic;
using System.Security.Claims;

using Kingpin.Tier.Entities.Classes;

namespace Kingpin.Tier.Services.Interfaces
{
    public interface ITokenService : IBaseService
    {
        JwtSecurityToken GenerateJwtToken(ApplicationUser applicationUser);

        string WriteJwtToken(JwtSecurityToken jwtSecurityToken);

        SymmetricSecurityKey GenerateSymmetricSecurityKey();

        SigningCredentials GenerateSigningCredentials(SymmetricSecurityKey symmetricSecurityKey);

        List<Claim> GenerateJwtClaims(ApplicationUser applicationUser);
    }
}
