using RC.Recloti.Business.DataTransferObject;
using RC.Recloti.Business.Interfaces;
using RC.Recloti.Business.Utils;
using RC.Recloti.Domain.Entities;
using RC.Recloti.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RC.Recloti.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> LoginValidator(LoginDto login, int idProfile)
        {
            var passEncrypted = Crypto.CryptoSHA1(login.Password);

            var user = await _userRepository.LoginValidator(login.Email, passEncrypted, idProfile);

            return user;
        }

        public async Task<bool> EmailExiste(string email, int idProfile) => await _userRepository.EmailExiste(email, idProfile);
    }
}
