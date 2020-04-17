using RC.Recloti.Data.Context;
using RC.Recloti.Domain.Entities;
using RC.Recloti.Domain.Interfaces.Repositories;
using RC.Recloti.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Recloti.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(ReclotiContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(bool sucesso, string message, User data)> Register(User user)
        {
            try
            {
                user.RegisterDate = DateTime.Now;
                user.UpdateDate = DateTime.Now;

                Save(user);

                await _unitOfWork.CommitAsync();

                return (true, "Usuário cadastrado com sucesso.", user);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<User> LoginValidator(string email, string password, int idProfile)
        {
            return (await CustomFind(x => x.Email.ToUpper().Equals(email.ToUpper()) &&
                                  x.Password.Equals(password) && x.Profile.Id == idProfile,
                                  x => x.Profile)).FirstOrDefault();
        }

        public async Task<bool> EmailExiste(string email, int idProfile) => (await CustomFind(x => x.Email.ToUpper().Equals(email.ToUpper()) && x.Profile.Id == idProfile)).Any();
    }
}
