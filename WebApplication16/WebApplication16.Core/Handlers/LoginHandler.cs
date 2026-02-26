using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication16.Core.Command;

namespace WebApplication16.Core.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IConfiguration _config;
        public LoginHandler(IConfiguration config)
        {
            _config = config;
        }
        public async Task<string> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            if (command.Username == "admin" && command.Password == "admin")
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,command.Username),
                    new Claim(JwtRegisteredClaimNames.Sub, command.Password),
                    new Claim(ClaimTypes.Role,"admin")
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60), 
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            return null; 
        }
    }
}
      
