using System;
using BaseApi.Dto;
using BaseApi.Models;
using BaseApi.Repository.UserRepository;
using BaseApi.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var responses = users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                //Age = user.Age,
                //Gender = user.Gender,
                //Posts = user.Posts.Select(post => new Post
                //{
                //    Id = post.Id,
                //    Content = post.Content,
                //}).ToList()
            }).ToList();

            return Ok(responses);
        }
    }
}
