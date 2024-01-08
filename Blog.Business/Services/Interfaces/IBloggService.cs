using Blog.Business.Dtos.BloggDtos;
using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services.Interfaces
{
    public interface IBloggService
    {
        public IEnumerable<BloggLIstItemDto> GetAll();
        public Task<BloggDetailDto> GetByIdAsync(int id);
        public Task CreateAsync(BlogCreateDto dto);
        public Task RemoveAsync(int id);
        public Task UpdateAsync(int id, BloggUpdateDto dto);

    }
}
