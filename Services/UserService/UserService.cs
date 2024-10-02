using AutoMapper;
using BaseApi.Dto;
using BaseApi.Repository.UserRepository;

namespace BaseApi.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());
            return users;
        }
    }
}
