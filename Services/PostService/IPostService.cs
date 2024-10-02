using BaseApi.Dto;
using BaseApi.Dto.Request;
using BaseApi.Models;

namespace BaseApi.Services.PostService
{
    public interface IPostService
    {
        public IEnumerable<PostDto> GetPosts();
        public Post CreatePost(Post post);
        public Task<bool> UpdatePost(UpdatePostRequestDto updatePost);
        public bool DeletePost(int Id);
    }
}
