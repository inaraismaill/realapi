using AutoMapper;
using Blog.Business.Dtos.TopicDtos;
using Blog.Core.Entities;

namespace Blog.Business.Proliles
{
    public class TopicMappingProfile : Profile
    {
        public TopicMappingProfile()
        {
            CreateMap<TopicCreateDTO, Topic>();
            CreateMap<TopicUpdateDTO, Topic>();
            CreateMap<Topic, TopicDetailDTO>();
            CreateMap<Topic, TopicListItemDTO>();
        }
    }
}
