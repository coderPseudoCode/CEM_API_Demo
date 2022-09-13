using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CEM_API.Services
{
    public class AuthService
    {
        private IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetAuthToken(string authUid, string authRole)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Role, authRole),
                new Claim(ClaimTypes.Name, authUid)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
            var credintials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Issuer"],
                audience: _configuration["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credintials);

            if (token == null)
            {
                throw new Exception();
            }

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
