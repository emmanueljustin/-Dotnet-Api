using AutoMapper;
using BaseApi.Dto;
using BaseApi.Models;
using BaseApi.Repository.PostRepository;
using BaseApi.Services.PostService;

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
    }
}
