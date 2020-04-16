using RC.Recloti.Business.DataTransferObject;
using RC.Recloti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RC.Recloti.Business.Interfaces
{
    public interface IUserService
    {
        Task<FullUserDto> ReturnFullUser(User user);
        Task<(bool sucesso, string message, User data)> Register(UserDto userDto);
        Task<(bool sucesso, string message, User data)> RegisterAccounts(UserDto userDto);


    }
}
