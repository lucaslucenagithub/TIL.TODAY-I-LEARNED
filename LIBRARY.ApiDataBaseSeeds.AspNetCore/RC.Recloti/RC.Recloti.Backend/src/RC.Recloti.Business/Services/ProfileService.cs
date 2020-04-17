using RC.Recloti.Business.DataTransferObject;
using RC.Recloti.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RC.Recloti.Business.Interfaces;
using RC.Recloti.Domain.Entities;

namespace RC.Recloti.Business.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<IEnumerable<Profile>> GetAllProfiles()
        {

            var profiles = await _profileRepository.GetAll();

            return profiles;
        }
    }
}
