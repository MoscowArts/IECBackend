using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IECBackend.Api.Common.Authentication.Jwt.Interfaces;
using IECBackend.Api.Features.Auth;
using IECBackend.Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace IECBackend.Api.Services;

public class JwtTokenService(IJwtSettings jwtSettings) : IJwtTokenService
{
    public Task<TokenDto> CreateAccessTokenAsync(ICollection<Claim> claims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));

        var expires = DateTime.UtcNow.AddHours(jwtSettings.TokenExpiresAfterHours);

        var token = new JwtSecurityToken(
            jwtSettings.Issuer,
            jwtSettings.Audience,
            claims,
            null,
            expires,
            new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return Task.FromResult(new TokenDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expires = expires
        });
    }
}