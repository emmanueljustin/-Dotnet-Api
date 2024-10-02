using System;
using AutoMapper;
using BaseApi.Dto;
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
        private readonly IMapper _mapper;

        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Post>))]
        public IActionResult GetPosts()
        {
            var posts = _mapper.Map<List<PostDto>>(_postRepository.GetPosts());

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
