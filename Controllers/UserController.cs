using System;
using BaseApi.Models;
using BaseApi.Repository.UserRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BaseApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : Controller
  {
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
    public IActionResult GetUsers()
    {
      var users = _userRepository.GetUsers();

      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      var responses = users.Select(user => new User {
        Id = user.Id,
        UserName = user.UserName,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Email = user.Email,
        Age = user.Age,
        Gender = user.Gender,
        Posts = user.Posts.Select(post => new Post {
           Id = post.Id,
           Content = post.Content,
        }).ToList()
      }).ToList();

      return Ok(responses);
    }
  }
}
