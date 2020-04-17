using RC.Recloti.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.Recloti.Domain.Entities
{
    public class Profile : BaseEntity
    {
        
        //For Seed
        private Profile(ProfileEnum @enum)
        {
            Id = (int)@enum;
            Description = @enum.ToString();
        }

        public Profile() { } //For Seed - EF
         
        //Props
        public string Description { get; set; }

        //For Seed

        public static implicit operator Profile(ProfileEnum @enum) => new Profile(@enum);

        public static implicit operator ProfileEnum(Profile p) => (ProfileEnum)p.Id;
    }
}
