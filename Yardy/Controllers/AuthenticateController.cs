using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Yardy.Models;
using Yardy.ViewModels;

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
        public IActionResult Post([FromBody] LoginRequestViewModel loginRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginStatus = user.AuthenticateUser(loginRequest.Username, loginRequest.Password);

                    if (loginStatus)
                    {
                        //get user info
                        var userDetails = user.GetUserInfo(loginRequest.Username, loginRequest.Password);

                        if (userDetails != null)
                        {
                            //Handle/set JWT 
                            var tokenHandler = new JwtSecurityTokenHandler();
                            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                            var tokenDescriptor = new SecurityTokenDescriptor
                            {
                                Subject = new ClaimsIdentity(new Claim[]
                                {
                                    new Claim(ClaimTypes.Name, userDetails.UserId.ToString())
                                }),
                                Expires = DateTime.UtcNow.AddDays(1),
                                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                            };

                            var token = tokenHandler.CreateToken(tokenDescriptor);
                            loginRequest.Token = tokenHandler.WriteToken(token);

                            loginRequest.Password = null;
                            loginRequest.UserTypeID = userDetails.RoleId;

                            return Ok(loginRequest);
                        }
                    }
                }

                loginRequest.Password = null;
                loginRequest.UserTypeID = 0;
                return Ok(loginRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
