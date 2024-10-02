using System;
using AutoMapper;
using BaseApi.Dto;
using BaseApi.Services.PostService;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {

        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PostDto>))]
        public IActionResult GetPosts()
        {
            var posts = _postService.GetPosts();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var responses = posts.Select(post => new PostDto
            {
                Id = post.Id,
                Content = post.Content,
                User = new UserDto
                {
                    Id = post.User.Id,
                    FirstName = post.User.FirstName,
                    LastName = post.User.LastName,
                }
            });

            return Ok(responses);
        }
    }
}
