using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RC.Recloti.Domain.Entities;

namespace RC.Recloti.Api.Controllers
{
    public class MainController : Controller
    {
        protected int Id { get; set; }
        protected string Name { get; set; }
        protected string Email { get; set; }
        protected string Profile { get; set; }
        //protected string Ip { get; set; }
        //protected string Device { get; set; }

        private readonly IConfiguration _configuration;

        public MainController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected object GenerateJwtToken(User user)
        {
            try
            {
                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id",user.Id.ToString()),
                new Claim("name",user.Name.ToString()),
                new Claim("email", user.Email.ToString()),
                new Claim(ClaimTypes.Role, user.Profile.Description.ToString())
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.UtcNow.AddDays(30);

                var token = new JwtSecurityToken(
                    _configuration["JwtIssuer"],
                    _configuration["JwtIssuer"],
                    claims,
                    expires: expires,
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);

            }
            catch (Exception ex)
            {
                return "Erro ao Gerar o Token ";
            }
        }

        protected bool ValidateToken(string Token, int id)
        {
            var token = new JwtSecurityToken(jwtEncodedString: Token);
            var idToken = token.Claims.First(c => c.Type == "id").Value;

            // Validate if the Token requested has same Id for the User thats logged.
            if (int.Parse(idToken) == id)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ClaimsIdentity identity = context.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                if (identity.Claims.Where(x => x.Type == "id").Any())
                    Id = int.Parse(identity.Claims.Where(x => x.Type == "id").First().Value);
                if (identity.Claims.Where(x => x.Type == "name").Any())
                    Name = identity.Claims.Where(x => x.Type == "name").First().Value;
                if (identity.Claims.Where(x => x.Type == "email").Any())
                    Email = identity.Claims.Where(x => x.Type == "email").First().Value;
                if (identity.Claims.Where(x => x.Type == ClaimTypes.Role).Any())
                    Profile = identity.Claims.Where(x => x.Type == ClaimTypes.Role).First().Value;
            }

            await base.OnActionExecutionAsync(context, next);
        }

    }
}