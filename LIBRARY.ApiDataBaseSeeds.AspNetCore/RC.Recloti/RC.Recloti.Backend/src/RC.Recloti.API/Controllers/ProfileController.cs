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
using RC.Recloti.Business.Interfaces;

namespace RC.Recloti.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class ProfileController : MainController
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authService;
        private readonly IProfileService _profileService;

        public ProfileController(IConfiguration configuration,
            ILogger logger, IUserService userService,
            IAuthenticationService authService, IProfileService profileService) : base(configuration)
        {
            _logger = logger;
            _userService = userService;
            _authService = authService;
            _profileService = profileService;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            try
            {

                var profiles = await _profileService.GetAllProfiles();

                if (profiles != null)
                    return Ok(new { sucesso = true, profiles });
                else
                    return Ok(new { sucesso = true, mensagem = "Lista de Perfil Vazia" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToLogString(Environment.StackTrace));
            }
        }
    }
}