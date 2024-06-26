﻿using Blog.Business.Repositories.Interfaces;
using Blog.Core.Entities.Common;
using Blog.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Business.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        BlogContext _context { get; }

        public GenericRepository(BlogContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool noTracking = true)
            => noTracking ? Table.AsNoTracking() : Table;

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        {
            return await Table.AnyAsync(expression);
        }

        public async Task CreateAsync(T data)
        {
            await Table.AddAsync(data);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id, bool noTracking = true)
        {
            return noTracking ? await Table.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id) : await Table.FindAsync(id);
        }

        public void Remove(T data)
        {
            Table.Remove(data);
        }
    }
}
