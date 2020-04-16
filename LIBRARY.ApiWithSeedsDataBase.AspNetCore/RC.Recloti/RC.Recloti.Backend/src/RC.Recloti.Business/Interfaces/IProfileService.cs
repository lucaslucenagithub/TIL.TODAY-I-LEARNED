using RC.Recloti.Business.DataTransferObject;
using RC.Recloti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RC.Recloti.Business.Interfaces
{
    public interface IProfileService
    {
        Task<IEnumerable<Profile>> GetAllProfiles();
    }
}
