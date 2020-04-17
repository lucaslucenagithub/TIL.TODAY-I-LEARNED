using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NLog;
using RC.Recloti.Api.Extensions;
using RC.Recloti.Business.DataTransferObject;
using RC.Recloti.Business.Interfaces;
using RC.Recloti.Domain.Enums;

namespace RC.Recloti.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class ClientController : MainController
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authService;

        public ClientController(IConfiguration configuration,
            ILogger logger, IUserService userService,
            IAuthenticationService authService) : base(configuration)
        {
            _logger = logger;
            _userService = userService;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserDto userDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emailExiste = await _authService.EmailExiste(userDto.Email, (int)ProfileEnum.Cliente);
                    if (emailExiste)
                        return Ok(new { sucesso = false, mensagem = "E-mail já cadastrado no sistema." });

                    var result = await _userService.Register(userDto);

                    return Ok(new { result.sucesso, result.message, result.data, token = GenerateJwtToken(result.data) });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToLogString(Environment.StackTrace));
            }

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto login)
        {
            try
            {
                var user = await _authService.LoginValidator(login, (int)ProfileEnum.Cliente);
                if (user != null)
                {
                    var fullUser = await _userService.ReturnFullUser(user);

                    return Ok(new { sucesso = true, token = GenerateJwtToken(user), result = fullUser });
                }
                else
                    return Ok(new { sucesso = false, mensagem = "Usuário ou senha inválida." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}