using RC.Recloti.Data.Context;
using RC.Recloti.Domain.Entities;
using RC.Recloti.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.Recloti.Data.Repositories
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(ReclotiContext context) : base(context)
        {
        }
    }
}
