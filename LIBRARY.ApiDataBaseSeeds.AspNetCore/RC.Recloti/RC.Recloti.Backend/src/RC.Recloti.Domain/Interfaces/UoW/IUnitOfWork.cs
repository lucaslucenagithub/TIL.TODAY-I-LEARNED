using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RC.Recloti.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
