using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yardy.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        //what will the user page need to display???
        [Required]
        public string Username { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
