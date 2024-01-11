using AutoMapper;
using Blog.Business.Dtos.AppUser;
using Blog.Business.Dtos.AuthDtos;
using Blog.Core.Entities;

namespace Blog.Business.Proliles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
