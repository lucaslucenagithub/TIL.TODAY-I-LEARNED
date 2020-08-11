using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Usuario.Models;

namespace Usuario.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("throwExceptionTeste")]
        public IActionResult GetExceptionTeste()
        {
            throw new Exception("Teste2");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUsuarios(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            // var claims = new List<Claim>
            // {
            //     new Claim(JwtRegisteredClaimNames.Sub, emailUsuario),
            //     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //     new Claim("id", idUsuario),
            //     new Claim("Nome", nome),
            //     new Claim("password", senha)
            // };

            // if (!string.IsNullOrWhiteSpace(perfil))
            // {
            //     claims.Add(new Claim(ClaimTypes.Role, perfil));
            // }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["JwtExpire"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuerIn"],
                expires: expires,
                signingCredentials: creds
            );

            var tokenRetorno = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(tokenRetorno);
        }
    }
}
