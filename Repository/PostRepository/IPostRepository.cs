using System;
using BaseApi.Dto.Request;
using BaseApi.Models;

namespace BaseApi.Repository.PostRepository
{
    public interface IPostRepository
    {
        ICollection<Post> GetPosts();
        public Post CreatePost(Post post);
        public Task<bool> UpdatePost(UpdatePostRequestDto updatePost);
        public bool DeletePost(int Id);
    }
}
