using System;
using System.Collections.Generic;
using System.Text;

namespace RC.Recloti.Business.DataTransferObject
{
    public class UserDto
    {
        public ProfileDto Profile { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Cellphone { get; set; }
        public string ProfilePhoto { get; set; }
        public bool Active { get; set; } = true;
        public DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
