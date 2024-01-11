using AutoMapper;
using Blog.Business.Dtos.TopicDtos;
using Blog.Business.Exceptions.Common;
using Blog.Business.Exceptions.Topic;
using Blog.Business.Repositories.Interfaces;
using Blog.Business.Services.Interfaces;
using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services.Implements
{
    public class TopicService : ITopicService
    {
        ITopicRepositories _repo { get; }
        IMapper _mapper { get; }


        public TopicService(ITopicRepositories repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(TopicCreateDTO dto)
        {
            if (await _repo.IsExistAsync(r => r.Name.ToLower() == dto.Name.ToLower()))
                throw new TopicExistException();
            await _repo.CreateAsync(_mapper.Map<Topic>(dto));
            await _repo.SaveAsync();
        }

        public IEnumerable<TopicListItemDTO> GetAll()
            => _mapper.Map<IEnumerable<TopicListItemDTO>>(_repo.GetAll());

        public async Task<TopicDetailDTO> GetByIdAsync(int id)
        {
            var data = await _checkId(id, true);
            return _mapper.Map<TopicDetailDTO>(data);
        }

        public async Task RemoveAsync(int id)
        {
            var data = await _checkId(id);
            _repo.Remove(data);
            await _repo.SaveAsync();
        }

        public async Task UpdateAsync(int id, TopicUpdateDTO dto)
        {
            var data = await _checkId(id);
            if (dto.Name.ToLower() != data.Name.ToLower())
            {
                if (await _repo.IsExistAsync(r => r.Name.ToLower() == dto.Name.ToLower()))
                    throw new TopicExistException();
                data = _mapper.Map(dto, data);
                await _repo.SaveAsync();
            }
        }

        async Task<Topic> _checkId(int id, bool isTrack = false)
        {
            if (id <= 0) throw new ArgumentException();
            var data = await _repo.GetByIdAsync(id, isTrack);
            if (data == null) throw new NotFoundException<Topic>();
            return data;
        }
    }
}
