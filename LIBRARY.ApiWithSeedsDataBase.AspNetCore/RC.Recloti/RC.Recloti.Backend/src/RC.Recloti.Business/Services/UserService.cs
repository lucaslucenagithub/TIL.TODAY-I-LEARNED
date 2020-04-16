using AutoMapper;
using RC.Recloti.Business.DataTransferObject;
using RC.Recloti.Business.Interfaces;
using RC.Recloti.Business.Utils;
using RC.Recloti.Domain.Entities;
using RC.Recloti.Domain.Enums;
using RC.Recloti.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RC.Recloti.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IProfileRepository _profileRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper
            , IProfileRepository profileRepository
            , IUserRepository userRepository)
        {
            _mapper = mapper;
            _profileRepository = profileRepository;
            _userRepository = userRepository;
        }

        public async Task<(bool sucesso, string message, User data)> Register(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            user.Profile = await _profileRepository.GetById((int)ProfileEnum.Cliente);
            user.Password = Crypto.CryptoSHA1(userDto.Password);

            var result = await _userRepository.Register(user);

            return (result.sucesso, result.message, result.data);
        }

        public async Task<(bool sucesso, string message, User data)> RegisterAccounts(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            user.Profile = await _profileRepository.GetById(userDto.Profile.Id);
            if(user.Profile == null)
                return (false, "Não foi possível cadastrar: o Perfil não existe.", user);
            user.Password = Crypto.CryptoSHA1(userDto.Password);

            var result = await _userRepository.Register(user);

            return (result.sucesso, result.message, result.data);
        }

        public async Task<FullUserDto> ReturnFullUser(User user)
        {

            var fullUser = new FullUserDto();

            fullUser.User = _mapper.Map<UserDto>(user);
            fullUser.Profile = _mapper.Map<ProfileDto>(user.Profile);

            return fullUser;
        }
    }
}
