using AutoMapper;
using Blog.Business.Dtos.BloggDtos;
using Blog.Business.Exceptions.Common;
using Blog.Business.Repositories.Interfaces;
using Blog.Business.Services.Interfaces;
using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Business.Exceptions.Topic;

namespace Blog.Business.Services.Implements
{
    public class BloggService : IBloggService
    {
        IBloggRepositories _repo { get; }
        IMapper _mapper { get; }
        public BloggService(IBloggRepositories repo,IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        async Task IBloggService.CreateAsync(BlogCreateDto dto)
        {
            if (await _repo.IsExistAsync(r => r.Description.ToLower() == dto.Description.ToLower()))
                throw new TopicExistException();

            //await _repo.CreateAsync(new Blogg
            //{
            //    Name = dto.Name,
            //});
            await _repo.CreateAsync(_mapper.Map<Blogg>(dto));
            await _repo.SaveAsync();
        }
        IEnumerable<BloggLIstItemDto> IBloggService.GetAll()
            => _mapper.Map<IEnumerable<BloggLIstItemDto>>(_repo.GetAll());
        //=> _repo.GetAll().Select(t => new BloggListItemDTO
        //{
        //    Id = t.Id,
        //    Name = t.Name,
        //});
        
        public async Task<BloggDetailDto> GetByIdAsync(int id)
        {
            var data = await _checkId(id, true);
            return _mapper.Map<BloggDetailDto>(data);
        }
        public async Task RemoveAsync(int id)
        {
            var data = await _checkId(id);
            _repo.Remove(data);
            await _repo.SaveAsync();
        }

        async Task<Blogg> _checkId(int id, bool isTrack = false)
        {
            if (id <= 0) throw new ArgumentException();
            var data = await _repo.GetByIdAsync(id, isTrack);
            if (data == null) throw new NotFoundException<Blogg>();
            return data;
        }
        public async Task UpdateAsync(int id, BloggUpdateDto dto)
        {
            var data = await _checkId(id);
            if (dto.Description.ToLower() != data.Description.ToLower())
            {
                if (await _repo.IsExistAsync(r => r.Description.ToLower() == dto.Description.ToLower()))
                    throw new TopicExistException();
                data = _mapper.Map(dto, data);
                await _repo.SaveAsync();
            }
        }
    }
}
