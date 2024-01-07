using Blog.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Business.Repositories.Interfaces
{
    public interface IGenericRepository <T> where T : BaseEntity
    {
        DbSet<T> Table {  get; }
        IQueryable<T> GetAll(bool noTracking = true);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id, bool noTracking = true);
        Task CreateAsync(T data);
        Task SaveAsync();
        void Remove(T data);
    }
}
