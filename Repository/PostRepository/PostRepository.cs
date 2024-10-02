using System;
using BaseApi.Data;
using BaseApi.Dto.Request;
using BaseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Repository.PostRepository
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Post> GetPosts()
        {
            return _context.Posts.Include(p => p.User).ToList();
        }

        public Post CreatePost(Post post)
        {
            // Add the post
            _context.Posts.Add(post);

            // Save the post in database
            _context.SaveChanges();

            return post;
        }

        public async Task<bool> UpdatePost(UpdatePostRequestDto updatePost)
        {
            var post = await _context.Posts.FindAsync(updatePost.Id);
            if (post == null)
            {
                return false;
            }

            post.Content = updatePost.Content;

            await _context.SaveChangesAsync();

            return true;
        }

        public bool DeletePost(int Id)
        {
            var post = _context.Posts.Find(Id);

            if (post == null)
            {
                return false;
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();

            return true;
        }
    }
}
