using Domain.Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AulaAPI.Statcs
{
    public static class TokenService
    {
        const string KEY = "a10350380af79a7d289c57d1ad9be5d0cec6d2ef";

        public static byte[] KEY_BYTES => Encoding.ASCII.GetBytes(KEY);

        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login.ToString()),
                    new Claim(ClaimTypes.Role, nameof(User.CreateCustomer)),
                    new Claim(ClaimTypes.Role, nameof(User.DeleteCustomer)),
                    new Claim(ClaimTypes.Role, nameof(User.UpdateCustomer))
                }),

                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
