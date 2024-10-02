using AutoMapper;
using BaseApi.Dto;
using BaseApi.Models;

namespace BaseApi.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<Post, PostDto>();
        }
    }
}
