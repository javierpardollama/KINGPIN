﻿using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.Settings.Classes;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kingpin.Tier.Services.Classes
{
    public class TokenService : BaseService, ITokenService
    {
        public TokenService(
           IConfiguration iConfiguration) : base(iConfiguration)
        {
        }

        public JwtSecurityToken GenerateJwtToken(string email, ApplicationUser identityUser)
        {
            return new JwtSecurityToken(
                JwtSettings.JwtIssuer,
                JwtSettings.JwtIssuer,
                GenerateJwtClaims(email, identityUser),
                expires: GenerateTokenExpirationDate(),
                signingCredentials: GenerateSigningCredentials(GenerateSymmetricSecurityKey())
            );
        }

        public string WriteJwtToken(JwtSecurityToken jwtSecurityToken) => new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        public SymmetricSecurityKey GenerateSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.JwtKey)); ;
        }

        public SigningCredentials GenerateSigningCredentials(SymmetricSecurityKey symmetricSecurityKey)
        {
            return new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256); ;
        }

        public DateTime GenerateTokenExpirationDate() => DateTime.Now.AddDays(JwtSettings.JwtExpireDays);

        public List<Claim> GenerateJwtClaims(string email, ApplicationUser identityUser)
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, identityUser.Id.ToString())
            };
        }
    }
}
