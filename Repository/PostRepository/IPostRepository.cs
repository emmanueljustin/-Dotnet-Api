using System;
using BaseApi.Models;

namespace BaseApi.Repository.PostRepository
{
  public interface IPostRepository
  {
    ICollection<Post> GetPosts();
    
  }
}
