﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

using Kingpin.Tier.Entities.Classes;
using Kingpin.Tier.Services.Interfaces;
using Kingpin.Tier.Settings.Classes;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Kingpin.Tier.Services.Classes
{
    /// <summary>
    /// Represents a <see cref="TokenService"/> interface. Inherits <see cref="BaseService"/>. Implemenets <see cref="ITokenService"/>
    /// </summary>
    public class TokenService : BaseService, ITokenService
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="TokenService"/>
        /// </summary>
        /// <param name="configuration">Injected <see cref="IConfiguration"/></param>
        public TokenService(
           IConfiguration @configuration) : base(@configuration)
        {
        }

        /// <summary>
        /// Generates Jwt Token
        /// </summary>
        /// <param name="applicationUser">Injected <see cref="ApplicationUser"/></param>
        /// <returns>Instance of <see cref="JwtSecurityToken"/></returns>
        public JwtSecurityToken GenerateJwtToken(ApplicationUser @applicationUser)
        {
            return new JwtSecurityToken(
                JwtSettings.JwtIssuer,
                JwtSettings.JwtAudience,
                GenerateJwtClaims(@applicationUser),
                expires: GenerateTokenExpirationDate(),
                signingCredentials: GenerateSigningCredentials(GenerateSymmetricSecurityKey())
            );
        }

        /// <summary>
        /// Writes Jwt Token
        /// </summary>
        /// <param name="jwtSecurityToken">>Injected <see cref="JwtSecurityToken"/></param>
        /// <returns>Instance of <see cref="string"/></returns>
        public string WriteJwtToken(JwtSecurityToken @jwtSecurityToken) => new JwtSecurityTokenHandler().WriteToken(@jwtSecurityToken);

        /// <summary>
        /// Generates Symmetric Security Key
        /// </summary>
        /// <returns>Instance of <see cref="SymmetricSecurityKey"/></returns>
        public SymmetricSecurityKey GenerateSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.JwtKey));
        }

        /// <summary>
        /// Generates Signing Credentials
        /// </summary>
        /// <param name="symmetricSecurityKey">>Injected <see cref="SymmetricSecurityKey"/></param>
        /// <returns>Instance of <see cref="SigningCredentials"/></returns>
        public SigningCredentials GenerateSigningCredentials(SymmetricSecurityKey @symmetricSecurityKey)
        {
            return new SigningCredentials(@symmetricSecurityKey,
                                          SecurityAlgorithms.HmacSha256);
        }

        /// <summary>
        /// Generates Token Expiration Date 
        /// </summary>
        /// <returns>Instance of <see cref="DateTime"/></returns>
        public DateTime GenerateTokenExpirationDate() => DateTime.Now.AddDays(JwtSettings.JwtExpireDays);

        /// <summary>
        /// Generates Jwt Claims
        /// </summary>
        /// <param name="applicationUser">>Injected <see cref="ApplicationUser"/></param>
        /// <returns>Instance of <see cref="List{Claim}"/></returns>
        public List<Claim> GenerateJwtClaims(ApplicationUser @applicationUser)
        {
            return new List<Claim>
            {
                new Claim(
                    JwtRegisteredClaimNames.Sub,
                    @applicationUser.Email),
                new Claim(
                    JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString()),
                new Claim(
                    ClaimTypes.NameIdentifier,
                    @applicationUser.Id.ToString()),
                new Claim(
                    ClaimTypes.Email,
                    @applicationUser.Email),
                new Claim(
                    JwtRegisteredClaimNames.Iss,
                    JwtSettings.JwtIssuer),
                new Claim(
                    JwtRegisteredClaimNames.Aud,
                    JwtSettings.JwtAudience),
                new Claim
                (
                    ClaimTypes.Role,
                    string.Join(",",@applicationUser.ApplicationUserRoles.Select(x=>x.ApplicationRole).Select(s=>s.Name).Distinct())),
            };
        }
    }
}
