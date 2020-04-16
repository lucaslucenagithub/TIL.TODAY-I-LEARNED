using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RC.Recloti.Business.DataTransferObject
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        //public long? IdFacebook { get; set; }
        //public string IdDispositivo { get; set; }
    }
}
