using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yardy.ViewModels
{
    public class LoginRequestViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string Token { get; set; }
        public int UserProfile { get; set; }    //user profile relationship
        public bool Active { get; set; }

        public int UserTypeID { get; set; }
    }
}
