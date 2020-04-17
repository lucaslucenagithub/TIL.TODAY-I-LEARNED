using RC.Recloti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RC.Recloti.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<(bool sucesso, string message, User data)> Register(User user);
        Task<User> LoginValidator(string email, string password, int idProfile);
        Task<bool> EmailExiste(string email, int idProfile);
    }
}
