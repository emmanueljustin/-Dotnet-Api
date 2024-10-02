using BaseApi.Dto;

namespace BaseApi.Services.UserService
{
    public interface IUserService
    {
        public IEnumerable<UserDto> GetUsers();
    }
}
