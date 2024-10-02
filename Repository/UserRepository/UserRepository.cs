using System;
using BaseApi.Data;
using BaseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Repository.UserRepository
{
  public class UserRepository : IUserRepository
  {
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
      _context = context;
    }

    public ICollection<User> GetUsers()
    {
      return _context.Users.Include(p => p.Posts).ToList();
    }
  }
}
