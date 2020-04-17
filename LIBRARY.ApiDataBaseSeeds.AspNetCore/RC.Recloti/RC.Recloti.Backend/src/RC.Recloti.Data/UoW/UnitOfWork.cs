using RC.Recloti.Data.Context;
using RC.Recloti.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RC.Recloti.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReclotiContext _context;

        public UnitOfWork(ReclotiContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
