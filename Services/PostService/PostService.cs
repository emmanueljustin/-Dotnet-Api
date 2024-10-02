using AutoMapper;
using BaseApi.Dto;
using BaseApi.Dto.Request;
using BaseApi.Models;
using BaseApi.Repository.PostRepository;

namespace BaseApi.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public IEnumerable<PostDto> GetPosts()
        {
            var posts = _mapper.Map<List<PostDto>>(_postRepository.GetPosts());
            return posts;
        }

        public Post CreatePost(Post post)
        {
            return _postRepository.CreatePost(post);
        }

        public async Task<bool> UpdatePost(UpdatePostRequestDto updatePost)
        {
            return await _postRepository.UpdatePost(updatePost);
        }

        public bool DeletePost(int Id)
        {
            return _postRepository.DeletePost(Id);
        }
    }
}
