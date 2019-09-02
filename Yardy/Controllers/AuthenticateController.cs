using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yardy.Models;

namespace Yardy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly AppSettings appSettings;
        private readonly IUser user;

        public AuthenticateController(AppSettings ap, IUser user)
        {
            appSettings = ap;
            this.user = user;
        }

        // POST: api/Authenticate
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginStatus = this.user.AuthenticateUser(user.Username, user.Password);

                    if (loginStatus)
                    {
                        //get user info

                        //Handle/set JWT 
                        
                    }
                    else
                    {
                        return Ok(user);
                    }
                }

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
