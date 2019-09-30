using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yardy.Models;
using Yardy.ViewModels;

namespace Yardy.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user;
        private readonly YardyDbContext _context;

        public UserController(YardyDbContext context, IUser u)
        {
            _context = context;
            user = u;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return user.GetAllUsers();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var res = user.GetUserByID(id);

            if (res == null)
            {
                return NotFound();
            }

            return res;
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                User u = new User();
                u.UserId = userViewModel.UserId;
                u.Username = userViewModel.Username;
                u.Password = userViewModel.Password;
                u.Active = userViewModel.Active;
            }

            if (id != userViewModel.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userViewModel).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!UserExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<User> PostUser(CreateUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (!user.CheckUserExists(viewModel.Username))
                {
                    User u = new User();
                    u.Username = viewModel.Username; //need encription
                    u.Password = viewModel.Password;
                    u.CreatedDate = DateTime.Now;
                    u.Active = true;

                    user.InsertUser(u);

                    return Ok(viewModel);
                }
                else
                {
                    //user exists already by that username
                    var response = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.Conflict
                    };

                    return BadRequest(new { error = "User already exists by that username" });
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
