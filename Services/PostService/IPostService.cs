using BaseApi.Dto;
using BaseApi.Models;

namespace BaseApi.Services.PostService
{
    public interface IPostService
    {
        public IEnumerable<PostDto> GetPosts();
    }
}
