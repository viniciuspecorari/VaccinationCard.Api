using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VaccinationCard.Api.Application.Models;
using VaccinationCard.Api.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VaccinationCard.Api.Repositories
{
    public class AuthRepository : IAuthRepository
    {
            private readonly IConfiguration _configuration;
        

            public AuthRepository(IConfiguration configuration)
            {
                _configuration = configuration;                                  
            }

            public async Task<Auth> Authenticate(string credential)
            {               

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"] ?? string.Empty));
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];

                var singinCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: new[]
                    {
                    new Claim(type: "credential_login", credential),                    
                    new Claim(type: ClaimTypes.Role, "master")
                    },
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: singinCredential
                    );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return new Auth
                {
                    Token = token,
                    Expired = DateTime.Now.AddHours(2)
                };
            }    
    }
}
