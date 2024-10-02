using System;
using BaseApi.Models;

namespace BaseApi.Repository.UserRepository
{
  public interface IUserRepository
  {
    ICollection<User> GetUsers();
  }
}
