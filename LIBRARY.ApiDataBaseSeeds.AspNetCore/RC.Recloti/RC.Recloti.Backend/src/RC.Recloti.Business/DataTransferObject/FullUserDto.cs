using System;
using System.Collections.Generic;
using System.Text;

namespace RC.Recloti.Business.DataTransferObject
{
    public class FullUserDto
    {
        public UserDto User { get; set; }
        public ProfileDto Profile { get; set; }
    }
}
