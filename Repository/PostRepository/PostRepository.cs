using System;
using BaseApi.Data;
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
    }
}
