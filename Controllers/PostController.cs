using System;
using BaseApi.Models;
using BaseApi.Repository.PostRepository;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class PostController : Controller
  {

    private readonly IPostRepository _postRepository;

    public PostController(IPostRepository postRepository)
    {
      _postRepository = postRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Post>))]
    public IActionResult GetPosts()
    {
      var posts = _postRepository.GetPosts();

      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      

      var responses = posts.Select(post => new Post {
        Id = post.Id,
        Content = post.Content,
        UserId = post.UserId,
        User = new User {
          Id = post.User.Id,
          FirstName = post.User.FirstName,
          LastName = post.User.LastName,
        }
      });

      return Ok(responses);
    }
  }
}
