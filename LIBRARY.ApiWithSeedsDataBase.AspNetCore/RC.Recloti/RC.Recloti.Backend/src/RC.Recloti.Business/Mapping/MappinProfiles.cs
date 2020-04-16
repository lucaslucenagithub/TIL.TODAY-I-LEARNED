using AutoMapper.Configuration;
using RC.Recloti.Business.DataTransferObject;
using RC.Recloti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.Recloti.Business.Mapping
{
    public class MappinProfiles : MapperConfigurationExpression
    {
        public MappinProfiles()
        {
            CreateMap<User, UserDto>()
                .ReverseMap();

            CreateMap<Profile, ProfileDto>()
               .ReverseMap();
        }
    }
}
