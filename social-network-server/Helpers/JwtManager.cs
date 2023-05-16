using Microsoft.IdentityModel.Tokens;
using SocialNetworkServer.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialNetworkServer.Helpers
{
    public static class JwtManager

    {
        public static TokenInformationDTO BuildToken (UserLoginDTO userLoginDTO, string secretKey, int preferredExpirationDays)
        {
            var claims = new List<Claim>() { new Claim("userName", userLoginDTO.UserName) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(preferredExpirationDays);

            var securityToken = new JwtSecurityToken(claims: claims, signingCredentials: credentials, expires: expiration);

            return new TokenInformationDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration
            };

        }
    }
}
