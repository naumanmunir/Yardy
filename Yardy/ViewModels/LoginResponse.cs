using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yardy.ViewModels
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public bool Status { get; set; }
        public int RoleId { get; set; }
    }
}
