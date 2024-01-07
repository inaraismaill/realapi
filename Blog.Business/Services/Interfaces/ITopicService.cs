using Blog.Business.Dtos.TopicDtos;
using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services.Interfaces
{
    public interface ITopicService
    {
        public IEnumerable<TopicListItemDTO> GetAll();
        public Task<TopicDetailDTO> GetByIdAsync(int id);
        public Task CreateAsync(TopicCreateDTO dto);
        public Task RemoveAsync(int id);
        public Task UpdateAsync(int id, TopicUpdateDTO dto);

    }
}
