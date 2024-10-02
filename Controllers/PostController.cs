using BaseApi.Dto;
using BaseApi.Dto.Request;
using BaseApi.Dto.Response;
using BaseApi.Models;
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

        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetPostResponseDto>))]
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

            var finalRes = new GetPostResponseDto
            {
                Status = "ok",
                Message = "Here is the list of posts.",
                Data = responses.ToList(),
            };

            return Ok(finalRes);
        }

        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(Post))]
        public IActionResult CreatePost([FromBody] CreatePostDto postRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = new Post
            {
                UserId = postRequest.UserId,
                Content = postRequest.Content,
            };

            var response = _postService.CreatePost(post); 
            return Ok(response);
        }

        [HttpPost("update")]
        [ProducesResponseType(200, Type = typeof(ResponseWithNoDataDto))]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostRequestDto updatePost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _postService.UpdatePost(updatePost);

            ResponseWithNoDataDto response;

            if (result)
            {
                response = new ResponseWithNoDataDto
                {
                    Status = "ok",
                    Message = "Post are succesfully updated."
                };
            }
            else
            {
                response = new ResponseWithNoDataDto
                {
                    Status = "err",
                    Message = "Oops! the data you are trying to modify does not exist."
                };
            }

            return Ok(response);
        }

        [HttpPost("delete")]
        [ProducesResponseType(200, Type = typeof(ResponseWithNoDataDto))]
        public IActionResult DeletePost([FromBody] IdRequestBodyDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _postService.DeletePost(data.Id);

            ResponseWithNoDataDto response;

            if (result)
            {
                response = new ResponseWithNoDataDto
                {
                    Status = "ok",
                    Message = "Post are succesfully deleted."
                };
            } else
            {
                response = new ResponseWithNoDataDto
                {
                    Status = "err",
                    Message = "Oops! the data you are trying to modify does not exist."
                };
            }

            return Ok(response);
        }
    }
}
