using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using VKUser.Database.Repository;
using VKUser.Models;

namespace VKUser.Controllers
{
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("users/get/{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest(401);
            }

            if (id is > 0)
            {
                var user = await _userRepository.GetAsync(id.Value);

                if (user != null)
                {
                    return Ok( new {user} );
                }

                return NotFound();
            }
            else
            {
                return BadRequest(400);
            }
        }

        [HttpPost("users/post/")]
        public async Task<IActionResult> Post(String login, String password, int userGroupId)
        {
            if ((login == null || login.Trim() == "") || (password == null || password.Trim() == "") || userGroupId == null)
                {
                    return BadRequest(401);
                }

                if (userGroupId <= 0)
                {
                    return BadRequest(400);
                }

                User existUser = new User();
                existUser = await _userRepository.GetAsync(login);
                
                if (existUser != null)
                {
                    return BadRequest("login already exists!");
                }

                if (userGroupId == 1 && !_userRepository.IsUserGroupOneAdmin())
                {
                    return BadRequest("you cannot add more than one admin to the system");
                }
                
                User newUser = new User();
                newUser.Login = login;
                newUser.Password = password;
                newUser.CreatedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTimeKind.Utc);
                newUser.UserStateId = 1;
                newUser.UserGroupId = userGroupId;
                
                await _userRepository.AddAsync(newUser);
            
                Thread.Sleep(5000);
                
                return Ok();
        }

        [HttpDelete("users/delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }

            var user = await _userRepository.GetAsync(id.Value);

            user.CreatedDate = new DateTime(user.CreatedDate.Year, user.CreatedDate.Month, user.CreatedDate.Day, user.CreatedDate.Hour, user.CreatedDate.Minute, user.CreatedDate.Second, DateTimeKind.Utc);
            user.UserStateId = 2;
   
            _userRepository.UpdateAsync(user);
            return Ok();
        }
    }
}