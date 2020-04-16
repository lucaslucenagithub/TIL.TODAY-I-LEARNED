using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RC.Recloti.Business.DataTransferObject;
using NLog;
using RC.Recloti.Business.Interfaces;
using Microsoft.Extensions.Configuration;
using RC.Recloti.Domain.Enums;
using RC.Recloti.Api.Extensions;

namespace RC.Recloti.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class AdminController : MainController
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authService;
        private readonly IProfileService _profileService;

        public AdminController(IConfiguration configuration,
            ILogger logger, IUserService userService,
            IAuthenticationService authService, IProfileService profileService) : base(configuration)
        {
            _logger = logger;
            _userService = userService;
            _authService = authService;
            _profileService = profileService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _authService.LoginValidator(login, (int)ProfileEnum.Administrador);
                    if (user != null)
                    {
                        var fullUser = await _userService.ReturnFullUser(user);

                        return Ok(new { sucesso = true, token = GenerateJwtToken(user), result = fullUser });
                    }
                    else
                        return Ok(new { sucesso = false, mensagem = "Usuário ou senha inválida." });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> RegisterAccounts([FromBody]UserDto userDto)
        {
            try
            {
                //Request input Token
                string auth = Request.Headers["Authorization"];
                var authXres = auth.Split(' ')[1];
                //Validate Token
                if (ValidateToken(authXres, userDto.Id))
                {
                    if (ModelState.IsValid)
                    {
                        userDto.Id = 0;
                        var emailExiste = await _authService.EmailExiste(userDto.Email, userDto.Profile.Id);
                        if (emailExiste)
                            return Ok(new { sucesso = false, mensagem = "E-mail já cadastrado no sistema." });

                        var result = await _userService.RegisterAccounts(userDto);

                        return Ok(new { result.sucesso, result.message, result.data, /*token = GenerateJwtToken(result.data)*/ });
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }
                else
                    return BadRequest(new { sucesso = false, mensagem = "Token ou usuário inválido." });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToLogString(Environment.StackTrace));
            }
        }
    }
}